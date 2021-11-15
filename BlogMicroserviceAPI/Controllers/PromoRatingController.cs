using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlogMicroservice.Application.Repositories.IRepositories;
using BlogMicroservice.Domain.Dtos;
using BlogMicroservice.Domain.Models;
using System.Threading.Tasks;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMicroservice.API.Controllers
{
    [Route("api/blogpromo/{blogPromoId:int}/promoRating")]
    [ApiController]
    public class PromoRatingController : ControllerBase
    {
        /*
            Herramientas para trabajar:
            WorkUnity - Por implementar.
         */
        private readonly IWorkUnity _workUnity;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public PromoRatingController(IWorkUnity workUnity,
                                     IMapper mapper)
        {
            //inicializar herramientas a utilizar
            _workUnity = workUnity;
            _mapper = mapper;
            _response = new ResponseDto();
        }


        [HttpPost]//Por medio de la unidad de trabajo
        public async Task<PostPutPromoRatingDto> AddRating(PostPutPromoRatingDto promoRatingDto)
        {
            var promoRating = _mapper.Map<PostPutPromoRatingDto, PromoRatingModel>(promoRatingDto);
            await _workUnity.PromoRating.AddT(promoRating);
            _workUnity.SaveData();
            return _mapper.Map<PromoRatingModel, PostPutPromoRatingDto>(promoRating);
        }


        [HttpGet]//Usando unidad de trabajo obteniendo el objeto promo mediante la url
        public async Task<ActionResult<IEnumerable<GetPromoRatingDto>>> GetRatings()
        {
            try
            {
                var listRatings = await _workUnity.PromoRating.GetTAll();
                _response.Result = listRatings;
                _response.DisplayMessage = "Listado de ratings";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }
            return Ok(_response);
          
        }


        [HttpPut("{id}")]//Por medio de unidad de trabajo, obteniendo obj mediante id
        public async Task<PostPutPromoRatingDto> UpdateRating(int id, PostPutPromoRatingDto promoRatingDto)
        {
            var promoRating = _mapper.Map<PostPutPromoRatingDto, PromoRatingModel>(promoRatingDto);
            try
            {
                    await _workUnity.PromoRating.Update(promoRating); 
            }
            catch (Exception ex)
            {
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return _mapper.Map<PromoRatingModel, PostPutPromoRatingDto>(promoRating);
        }

        //Metodo Delete por medio de Unidad de trabajo
        [HttpDelete]
        public async Task<bool> DeleteRating(int ratingId)
        {
            if (RatingExists(ratingId))
            {
                await _workUnity.PromoRating.RemoveT(ratingId);
                _workUnity.SaveData();
            }
            return true;
        }

        //Metodo para determinar si existe el obj
        private bool RatingExists(int id)
        {
            return true;
        }
    }
}
