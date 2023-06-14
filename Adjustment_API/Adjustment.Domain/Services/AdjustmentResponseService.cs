using Adjustment.Domain.Interfaces;
using Adjustment.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Domain.Services
{
    public class AdjustmentResponseService : IAdjustmentResponseService
    {
        private readonly IAdjustmentResponse _IAdjustmentResponse;
        private readonly IAdjustmentResponseService _IAdjustmentResponseService;
        private readonly ILogger<AdjustmentResponse> _Logger;

        public AdjustmentResponseService(IAdjustmentResponse iAdjustmentResponse, ILogger<AdjustmentResponse> Logger)
        {
            _IAdjustmentResponse = iAdjustmentResponse;
            _Logger = Logger;
        }

        public async Task<List<AdjustmentResponse>> CalculateAdjustment(DataResponse dataResponse)
        {
            List<AdjustmentResponse> adjustmentResponsesList = new List<AdjustmentResponse>();

            if (IsOutOfDateTime(dataResponse))
            {
                return adjustmentResponsesList;
            }

            List<CalculedAdjustment> calculedAdjustmentsList = CalculateAdjustmentsCaseOutOfTolerance(dataResponse);

            if (calculedAdjustmentsList.Count == 0)
            {
                return adjustmentResponsesList;
            }

            //For each CalculedAdjustment object, create,send and add a new AdjustmentResponse
            foreach (CalculedAdjustment calculedAdjustment in calculedAdjustmentsList)
            {
                AdjustmentResponse adjustmentResponse = new AdjustmentResponse
                {
                    AdjustmentDate = DateTime.Now,
                    AdjustmentMachine = dataResponse.resultData.MachineName,
                    CalculedAdjustments = calculedAdjustment 
                };

                adjustmentResponsesList.Add(adjustmentResponse);
                await SendToAdjustmentComponent(adjustmentResponse);
                await AddAdjustmentResponse(adjustmentResponse);
            }
            return adjustmentResponsesList;
        }

        public async Task SendToAdjustmentComponent(AdjustmentResponse adjustmentResponse)
        {

            await _IAdjustmentResponseService.SendToAdjustmentComponent(adjustmentResponse);
        }

        public async Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse)
        {
            await _IAdjustmentResponse.AddAdjustmentResponse(adjustmentResponse);
        }

        private bool IsOutOfDateTime(DataResponse dataResponse)
        {
            TimeSpan dateDiff = dataResponse.GeneratedDate - dataResponse.resultData.ResultDate;
            
            if(dateDiff.Minutes > 5)
            {
                _Logger.LogInformation(
                        "Adjustment not applicable, ResultDate is too old " + 
                        "ResultDate: " + dataResponse.resultData.ResultDate.ToString() + " " +
                        "Actual Date: " + dataResponse.GeneratedDate.ToString()
                        );

                return true;
            }
            return false;       
        }
        private List<CalculedAdjustment> CalculateAdjustmentsCaseOutOfTolerance(DataResponse dataResponse)
        {
            List<CalculedAdjustment> calculedAdjustments = new List<CalculedAdjustment>();

            if (dataResponse.resultData.AngleResult > dataResponse.resultData.AngleUpperTol)
            {
                CalculedAdjustment calculedAdjustment = new CalculedAdjustment
                {
                    Characteristic = "Angle",
                    Quantity = dataResponse.resultData.AngleUpperTol - dataResponse.resultData.AngleResult
                };
                calculedAdjustments.Add(calculedAdjustment);
            }

            if (dataResponse.resultData.AngleResult < dataResponse.resultData.AngleLowerTol)
            {
                CalculedAdjustment calculedAdjustment = new CalculedAdjustment
                {
                    Characteristic = "Angle",
                    Quantity = dataResponse.resultData.AngleLowerTol - dataResponse.resultData.AngleResult
                };
                calculedAdjustments.Add(calculedAdjustment);
            }
            ////////////////////////////// - DIAMETER - //////////////////////////////
            if (dataResponse.resultData.DiameterResult > dataResponse.resultData.DiameterUpperTol)
            {
                CalculedAdjustment calculedAdjustment = new CalculedAdjustment
                {
                    Characteristic = "Diameter",
                    Quantity = dataResponse.resultData.DiameterUpperTol - dataResponse.resultData.DiameterResult
                };
                calculedAdjustments.Add(calculedAdjustment);
            }

            if (dataResponse.resultData.DiameterResult < dataResponse.resultData.DiameterLowerTol)
            {
                CalculedAdjustment calculedAdjustment = new CalculedAdjustment
                {
                    Characteristic = "Diameter",
                    Quantity = dataResponse.resultData.DiameterLowerTol - dataResponse.resultData.DiameterResult
                };
                calculedAdjustments.Add(calculedAdjustment);
            }

            calculedAdjustments.ForEach(calculedAdjustment =>
                _Logger.LogInformation(
                    "Adjustment applicable to " + calculedAdjustment.Characteristic +
                    " Quantity: " + calculedAdjustment.Quantity
                ));

            return calculedAdjustments;
        }


    }
}
