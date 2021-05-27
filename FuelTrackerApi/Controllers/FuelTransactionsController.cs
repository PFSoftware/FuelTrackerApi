using AutoMapper;
using FuelTrackerApi.Models.Api.Requests;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
using FuelTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FuelTrackerApi.Controllers
{
    [Route("api/fueltransactions")]
    [ApiController]
    public class FuelTransactionsController : ControllerBase
    {
        private readonly FuelTransactionService _service;
        private readonly IMapper _mapper;

        public FuelTransactionsController(FuelTransactionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/fueltransactions
        [HttpGet]
        public ActionResult<IEnumerable<FuelTransactionViewModel>> GetAllFuelTransactions()
        {
            IEnumerable<FuelTransaction> fuelTransactionItems = _service.GetAllFuelTransactions();

            return Ok(_mapper.Map<IEnumerable<FuelTransactionViewModel>>(fuelTransactionItems));
        }

        //GET api/fueltransactions/{id}
        [HttpGet("{id}", Name = "GetFuelTransactionById")]
        public ActionResult<FuelTransactionViewModel> GetFuelTransactionById(int id)
        {
            FuelTransaction fuelTransactionItem = _service.GetFuelTransactionById(id);
            if (fuelTransactionItem != null)
                return Ok(_mapper.Map<FuelTransactionViewModel>(fuelTransactionItem));

            return NotFound();
        }

        //POST api/fueltransactions
        [HttpPost]
        public ActionResult<FuelTransactionViewModel> CreateFuelTransaction(CreateEditFuelTransactionRequest request)
        {
            FuelTransaction newFuelTransaction = _mapper.Map<FuelTransaction>(request);
            _service.CreateFuelTransaction(newFuelTransaction);

            var fuelTransactionViewModel = _mapper.Map<FuelTransactionViewModel>(newFuelTransaction);

            return CreatedAtRoute(nameof(GetFuelTransactionById), new { Id = fuelTransactionViewModel.Id }, fuelTransactionViewModel);
        }

        //POST api/fueltransactions/{id}
        [HttpPost("{id}")]
        public ActionResult UpdateFuelTransaction(int id, CreateEditFuelTransactionRequest request)
        {
            FuelTransaction fuelTransaction = _service.GetFuelTransactionById(id);
            if (fuelTransaction == null)
                return NotFound();

            if (request.Id != null && request.Id != id)
                return ValidationProblem("The ID in the model doesn't match the ID the request was made on.");

            _service.UpdateFuelTransaction(request, fuelTransaction);
            return NoContent();
        }

        //DELETE api/fueltransactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFuelTransaction(int id)
        {
            FuelTransaction fuelTransaction = _service.GetFuelTransactionById(id);
            if (fuelTransaction == null)
                return NotFound();

            _service.DeleteFuelTransaction(fuelTransaction);
            return NoContent();
        }
    }
}