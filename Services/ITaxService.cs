using System.Threading.Tasks;
using IMC_codeChallenge.Helper;
namespace IMC_codeChallenge.Services;

public interface ITaxService
{
     Task<TaxRateResponse> GetTaxRatesForLocation(string ApiKey, string zipCode);
}