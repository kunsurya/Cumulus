using System.Collections.Generic;
using RestSharp;
using System.Linq;
using System.Net;
using RestSharp.Authenticators;
using RestSharp.Serializers;

namespace Cumulus
{
    public class VCloudClient
    {
        private RestClient _client;
        private readonly Parameters _parameters;

        public VCloudClient(string baseUrl, Parameters parameters)
        {
            this._parameters = parameters;
            _client = new RestClient(baseUrl) {Authenticator = new HttpBasicAuthenticator(parameters.Username, parameters.Password)};
        }

        public string Reset()
        {
            //Login
            var request = new RestRequest("api/sessions", Method.POST);
            request.AddHeader("Accept", "application/*+xml;version=1.5");
            _client.Authenticator.Authenticate(_client, request);
            var response = _client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Get All vApps
                request = new RestRequest("api/query/?type=vApp", Method.GET);
                request.AddHeader("Accept", "application/*+xml;version=1.5");
                var authToken = response.Headers.ToList()
                    .Find(x => x.Name == "x-vcloud-authorization")
                    .Value.ToString();
                request.AddHeader("x-vcloud-authorization", authToken);
                request.XmlSerializer = new XmlSerializer();

                response = _client.Execute<List<VAppRecord>>(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var vApp =
                        ((RestResponse<List<VAppRecord>>) response).Data
                            .FirstOrDefault(x => x.Name == _parameters.VAppName);
                    if (vApp != null)
                    {
                        //Get LeaseSettingsSection for specific vApp
                        _client = new RestClient(vApp.Href + "/leaseSettingsSection");
                        request = new RestRequest(Method.GET);
                        request.AddHeader("Accept", "application/*+xml;version=1.5");
                        request.AddHeader("x-vcloud-authorization", authToken);
                        response = _client.Execute(request);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            // Perform lease reset
                            request = new RestRequest(Method.PUT);
                            request.AddHeader("Accept", "application/*+xml;version=1.5");
                            request.AddHeader("x-vcloud-authorization", authToken);
                            request.AddParameter("application/vnd.vmware.vcloud.leasesettingssection+xml",
                                response.Content, ParameterType.RequestBody);
                            response = _client.Execute(request);
                            if (response.StatusCode == HttpStatusCode.Accepted ||
                                response.StatusCode == HttpStatusCode.OK)
                            {
                                return "Success!";
                            }
                            else
                            {
                                return "Error resetting Lease";
                            }
                        }
                        else
                        {
                            return "Error retrieving lease for the vApp.";
                        }
                    }
                    else
                    {
                        return "Error: vApp not found.";
                    }
                }
                else
                {
                    return "Error retrieving vApp(s).";
                }
            }
            else
            {
                return "Error: Failed to authenticate.";
            }
        }
    }
}
