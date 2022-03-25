using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using IMC_codeChallenge.Helper;
using IMC_codeChallenge.Model;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace IMC_codeChallenge.Services;

public class TaxService : ITaxService
{
    private string baseURL = "https://api.taxjar.com/v2/rates/{0}";
    public async Task<TaxRateResponse> GetTaxRatesForLocation(string ApiKey, string zipCode)
    {
        var clinet = new RestClient();
        var request = new RestRequest(String.Format(baseURL, zipCode), Method.Get);
        request.AddHeader("Authorization", String.Format("Bearer {0}", ApiKey));
        var response = await clinet.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            var data = JsonConvert.DeserializeObject<TaxRateResponse>(response.Content);

            return data;
        }
        else
        {
            return null;
        }
    }
}