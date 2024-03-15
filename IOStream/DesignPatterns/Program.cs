namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*try ===> one
            {
                var result = await currency.GetCurrencies();
                Console.WriteLine(result);
            }
            catch
            {
                throw;
            }
            finally
            {
                currency?.Dispose();
            }*/

            /*using (var currency = new CurrencyServic())
            {
                var result = currency.GetCurrencies();
                Console.WriteLine(result);
            }*/

            var t = new StringWriter();
            t.Write("Anas");
            t.Write("Anas");
            t.Write("Anas");
            t.Write("Anas");
            t.Write("Anas");
            t.Write("Anas");
            var s = t.ToString();
            Console.WriteLine(s);
        }
    }


    class CurrencyServic:IDisposable
    {
        private readonly HttpClient _httpClient = null;
        private bool _dispose = false;
        public CurrencyServic()
        {
            _httpClient = new HttpClient();
        }

        ~CurrencyServic()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing) 
        {
            //if disposing=> clean managed and unmanaged codee
            //else => clean only unmanaged
            if (_dispose) return;
            if (disposing) _httpClient.Dispose();
            _dispose = true;
            //clean unmanaged code
        }

        public   string GetCurrencies()
        {
            string url = @"https://restcountries.com/v3.1/all";
            var result =_httpClient.GetStringAsync(url).Result;
            return result;
        }
    }
}
