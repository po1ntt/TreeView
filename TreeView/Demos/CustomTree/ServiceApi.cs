using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TreeView.Controls.CustomTreeView.CustomTree;

namespace TreeView.Demos.CustomTree
{
    public class ServiceApi
    {
        public HttpClient httpclient;
        private readonly string Adress;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public ServiceApi()
        {
            httpclient = new HttpClient();
            Adress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5005" : "https://localhost:7127";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }
        public async Task<List<NodeTree>> GetInfoAboutDirectory(string path)
        {
            List<NodeTree> itemTrees = new List<NodeTree>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return itemTrees;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/TreeView/GetNodeTree?path={path}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    itemTrees = JsonSerializer.Deserialize<List<NodeTree>>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return itemTrees;
            }
            return itemTrees;
        }
    }

}
