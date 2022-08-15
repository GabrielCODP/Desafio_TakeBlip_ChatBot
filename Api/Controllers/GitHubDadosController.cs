using Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubDadosController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<GitHubViewModel>> GetRepositoriesGithub()
        {
            try
            {
                var requestRepositorio = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/users/takenet/repos?sort=created&direction=asc");


                //Servidor necessida de um User-Agent
                requestRepositorio.Headers.Add("Accept", "application/vnd.github.v3+json");
                requestRepositorio.Headers.Add("User-Agent", "GabrielCODP");

                var clientHttp = new HttpClient();
                HttpResponseMessage response = await clientHttp.SendAsync(requestRepositorio);

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();

                    var list = await JsonSerializer.DeserializeAsync
                        <IEnumerable<GitHubViewModel>>(responseStream);


                    //Os dados já vem ordendado da menor data de criação "ASC".

                    return list.Where(X => X.Language == "C#").Take(5);
                }

                return Enumerable.Empty<GitHubViewModel>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
