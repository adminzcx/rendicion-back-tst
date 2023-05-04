using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.ImportExcelFile;
using Quartz;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Api.Web.Jobs
{
    [DisallowConcurrentExecution]
    public class FtpJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;
        private static HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public FtpJob(IServiceProvider serviceProvider, IConfiguration configuration)
        {

            _serviceProvider = serviceProvider;
            _configuration = configuration;

        }

        public async Task Execute(IJobExecutionContext context)
        {

            //await this.DownloadFilesAsync();


        }


        public async Task DownloadFilesAsync()

        {

            var model = new ImportExcelFileCommand() { };
            var serializedPosterForCreation = JsonConvert.SerializeObject(model);
            var endpoint = _configuration["FTP:ApiEndPoint"];

            _httpClient.BaseAddress = new Uri(endpoint);
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/Lunch/ImportFiles");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedPosterForCreation);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

        }

    }
}
