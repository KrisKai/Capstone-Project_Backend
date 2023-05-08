using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Helpers.Exceptions;
using JourneySick.Business.Models.DTOs;
using JourneySick.Business.Security;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.DTOs.CommonDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.VO;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.Entities.VO;
using JourneySick.Data.Models.Enums;
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
                List<TblfeedbackVO> tblusers = await _feedbackRepository.GetAllFeedbacksWithPaging(pageIndex, pageSize, tripId);
                // convert entity to dto
                List<FeedbackVO> users = _mapper.Map<List<FeedbackVO>>(tblusers);
                int count = await _feedbackRepository.CountAllFeedbacks(tripId);
                result.ListOfFeedback = users;
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
                Tblfeedback tblFeedbackDTO = await _feedbackRepository.GetFeedbackById(feedbackId);
                // convert entity to dto
                FeedbackDTO feedbackDTO = _mapper.Map<FeedbackDTO>(tblFeedbackDTO);

                return feedbackDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.StackTrace, ex);
                throw;
            }

        }

        public async Task<int> CreateFeedback(FeedbackDTO feedbackDTO, CurrentUserObj currentUser)
        {
            try
            {
                    feedbackDTO.FldCreateBy = currentUser.UserId;
                    feedbackDTO.FldCreateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Tblfeedback userEntity = _mapper.Map<Tblfeedback>(feedbackDTO);
                    if (await _feedbackRepository.CreateFeedback(userEntity) > 0)
                    {
                        return userEntity.FldFeedbackId;
                    }
                
                throw new InsertException("Create Feedback failed!");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace, ex);
                throw;
            }
        }

        public async Task<int> UpdateFeedback(FeedbackDTO feedbackDTO, CurrentUserObj currentUser)
        {
            try
            {
                FeedbackDTO getTrip = await GetFeedbackById((int)feedbackDTO.FldFeedbackId);

                if (getTrip != null)
                {
                    feedbackDTO.FldUpdateBy = currentUser.UserId;
                    feedbackDTO.FldUpdateDate = DateTimePicker.GetDateTimeByTimeZone();
                    Tblfeedback tblfeedbackDTO = _mapper.Map<Tblfeedback>(feedbackDTO);
                    int id = await _feedbackRepository.UpdateFeedback(tblfeedbackDTO);
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
                List<TblfeedbackVO> tblusers = await _feedbackRepository.GetTopFeedback();
                // convert entity to dto
                List<FeedbackVO> users = _mapper.Map<List<FeedbackVO>>(tblusers);
                int count = await _feedbackRepository.CountAllFeedbacks(null);
                result.ListOfFeedback = users;
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
                        getTrip.FldLike++;
                    }
                    else if(status.Equals("D")) { 
                        getTrip.FldDislike++;
                    }
                    Tblfeedback tblfeedbackDTO = _mapper.Map<Tblfeedback>(getTrip);
                    int id = await _feedbackRepository.IncreaseLike(tblfeedbackDTO, status);
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
