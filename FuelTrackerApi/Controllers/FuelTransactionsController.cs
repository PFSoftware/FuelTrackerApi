using AutoMapper;
using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FuelTrackerApi.Controllers
{
    [Route("api/fueltransactions")]
    [ApiController]
    public class FuelTransactionsController : ControllerBase
    {
        private readonly IFuelTransactionData _repository;
        private readonly IMapper _mapper;

        public FuelTransactionsController(IFuelTransactionData repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/fueltransactions
        [HttpGet]
        public ActionResult<IEnumerable<FuelTransactionViewModel>> GetAllCommmands()
        {
            IEnumerable<FuelTransaction> fuelTransactionItems = _repository.GetAllFuelTransactions();

            return Ok(_mapper.Map<IEnumerable<FuelTransactionViewModel>>(fuelTransactionItems));
        }

        //GET api/fueltransactions/{id}
        [HttpGet("{id}", Name = "GetFuelTransactionById")]
        public ActionResult<FuelTransactionViewModel> GetFuelTransactionById(int id)
        {
            FuelTransaction fuelTransactionItem = _repository.GetFuelTransactionById(id);
            if (fuelTransactionItem != null)
            {
                return Ok(_mapper.Map<FuelTransactionViewModel>(fuelTransactionItem));
            }
            return NotFound();
        }

        //POST api/fueltransactions
        [HttpPost]
        public ActionResult<FuelTransactionViewModel> CreateFuelTransaction(FuelTransactionViewModel fuelTransaction)
        {
            FuelTransaction fuelTransactionModel = _mapper.Map<FuelTransaction>(fuelTransaction);
            _repository.CreateFuelTransaction(fuelTransactionModel);
            _repository.SaveChanges();

            var FuelTransactionViewModel = _mapper.Map<FuelTransactionViewModel>(fuelTransactionModel);

            return CreatedAtRoute(nameof(GetFuelTransactionById), new { Id = FuelTransactionViewModel.TransactionId }, FuelTransactionViewModel);
        }

        //PUT api/fueltransactions/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFuelTransaction(int id, FuelTransaction fuelTransaction)
        {
            FuelTransaction fuelTransactionModelFromRepo = _repository.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(fuelTransaction, fuelTransactionModelFromRepo);

            _repository.UpdateFuelTransaction(id, fuelTransactionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/fueltransactions/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialFuelTransactionUpdate(int id, JsonPatchDocument<FuelTransaction> patchDoc)
        {
            FuelTransaction fuelTransactionModelFromRepo = _repository.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }

            FuelTransaction fuelTransactionToPatch = _mapper.Map<FuelTransaction>(fuelTransactionModelFromRepo);
            patchDoc.ApplyTo(fuelTransactionToPatch, ModelState);

            if (!TryValidateModel(fuelTransactionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(fuelTransactionToPatch, fuelTransactionModelFromRepo);

            _repository.UpdateFuelTransaction(id, fuelTransactionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/fueltransactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFuelTransaction(int id)
        {
            FuelTransaction fuelTransactionModelFromRepo = _repository.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteFuelTransaction(fuelTransactionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}