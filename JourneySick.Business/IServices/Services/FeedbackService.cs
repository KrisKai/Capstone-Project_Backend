using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Helpers.SettingObject;
using JourneySick.Data.IRepositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JourneySick.Business.IServices.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FeedbackService> _logger;
        private readonly AppSecrect _appSecrect;

        public FeedbackService(IFeedbackRepository userRepository, IOptions<AppSecrect> appSecrect, IMapper mapper, ILogger<FeedbackService> logger)
        {
            _feedbackRepository = userRepository;
            _appSecrect = appSecrect.Value;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AllFeedbackDTO> GetAllFeedbacksWithPaging(int pageIndex, int pageSize, string? tripId)
        {
            AllFeedbackDTO result = new();
            try
            {
                List<FeedbackVO> feedbacks = await _feedbackRepository.GetAllFeedbacksWithPaging(pageIndex, pageSize, tripId);
                // convert entity to dto
                List<FeedbackRequest> feedbackRequests = _mapper.Map<List<FeedbackRequest>>(feedbacks);
                int count = await _feedbackRepository.CountAllFeedbacks(tripId);
                result.ListOfFeedback = feedbackRequests;
                result.NumOfFeedback = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<FeedbackDTO> GetFeedbackById(int feedbackId)
        {
            try
            {
                Feedback FeedbackDTO = await _feedbackRepository.GetFeedbackById(feedbackId);
                // convert entity to dto
                FeedbackDTO feedbackDTO = _mapper.Map<FeedbackDTO>(FeedbackDTO);

                return feedbackDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<int> CreateFeedback(FeedbackDTO feedbackDTO, CurrentUserObject currentUser)
        {
            try
            {
                    feedbackDTO.CreateBy = currentUser.UserId;
                    feedbackDTO.CreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Feedback userEntity = _mapper.Map<Feedback>(feedbackDTO);
                    if (await _feedbackRepository.CreateFeedback(userEntity) > 0)
                    {
                        return userEntity.FeedbackId;
                    }
                
                throw new InsertException("Create Feedback failed!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateFeedback(FeedbackDTO feedbackDTO, CurrentUserObject currentUser)
        {
            try
            {
                FeedbackDTO getTrip = await GetFeedbackById((int)feedbackDTO.FeedbackId);

                if (getTrip != null)
                {
                    feedbackDTO.UpdateBy = currentUser.UserId;
                    feedbackDTO.UpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Feedback feedback = _mapper.Map<Feedback>(feedbackDTO);
                    int id = await _feedbackRepository.UpdateFeedback(feedback);
                    if (id > 0)
                    {
                        return id;
                    }
                    else
                    {
                        throw new UpdateException("Update Feedback failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Feedback is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> DeleteFeedback(int feedbackId)
        {
            try
            {
                FeedbackDTO getTrip = await GetFeedbackById(feedbackId);

                if (getTrip != null)
                {
                    if (await _feedbackRepository.DeleteFeedback(feedbackId) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new DeleteException("Delete feedback failed!");
                    }

                }
                else
                {
                    throw new GetOneException("Feedback is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<AllFeedbackDTO> GetTopFeedback()
        {
            AllFeedbackDTO result = new();
            try
            {
                List<FeedbackVO> feedbacks = await _feedbackRepository.GetTopFeedback();
                // convert entity to dto
                List<FeedbackRequest> feedbackRequests = _mapper.Map<List<FeedbackRequest>>(feedbacks);
                int count = await _feedbackRepository.CountAllFeedbacks(null);
                result.ListOfFeedback = feedbackRequests;
                result.NumOfFeedback = count;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> IncreaseLike(int feedbackId, string status)
        {
            try
            {
                FeedbackDTO getTrip = await GetFeedbackById(feedbackId);

                if (getTrip != null)
                {
                    if(status.Equals("L")) {
                        getTrip.Like++;
                    }
                    else if(status.Equals("D")) { 
                        getTrip.Dislike++;
                    }
                    Feedback feedbackDTO = _mapper.Map<Feedback>(getTrip);
                    int id = await _feedbackRepository.IncreaseLike(feedbackDTO, status);
                    if (id > 0)
                    {
                        return id;
                    }
                    else
                    {
                        throw new UpdateException("Update failed!");
                    }
                }
                else
                {
                    throw new GetOneException("Feedback is not existed!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }
    }
}
