using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stampin.Api.Common;

namespace Stampin.Api.IntegrationTests
{
  public class IntegrationTest
  {
    public readonly string baseUri = "http://localhost:44338/api/";
    private readonly string GetTreeAddr = "Tree/GetTrees";
    private readonly string CreateTreeAddr = "Tree/CreateTrees";
    public void RunTests()
    {
      GetTreeTest();
      this.CreateTrees();
    }

    public void GetTreeTest()
    {
      string args = "{UseId=true&UseName=false&=false&UseAveSize=false&UseDeciduous=false&UseConifer=false&UseFallColor=false&UseSpringFlowers=false}";
      GetTreesResponse response = this.Get<GetTreesResponse>(args, this.GetTreeAddr);
    }

    public void CreateTrees()
    {
      CreateTreesResponse response = this.Post<CreateTreesResponse, CreateTreesRequest>(new CreateTreesRequest(), this.CreateTreeAddr);
    }



    private T Get<T>(string args, string uri)
    {
      try
      {
        var encoding = new ASCIIEncoding();

        var httpWReq = (HttpWebRequest)WebRequest.Create(this.baseUri + uri + args);
        httpWReq.Method = "Get";
        httpWReq.ContentType = "application/json";
        var response = (HttpWebResponse)httpWReq.GetResponse();
        string jsonResult = new StreamReader(response.GetResponseStream()).ReadToEnd();
        if (typeof(T) == typeof(string))
        {
          jsonResult = "\"" + jsonResult + "\"";
        }

        T result = JsonConvert.DeserializeObject<T>(jsonResult);
        return result;
      }
      catch (Exception ex)
      {
        var e = ex;
        throw;
      }
    }


    private T Post<T, TR>(TR request, string uri)
    {
      try
      {
        string json = JsonConvert.SerializeObject(request);
        var encoding = new ASCIIEncoding();

        var httpWReq = (HttpWebRequest)WebRequest.Create(this.baseUri + uri);
        httpWReq.Method = "POST";
        httpWReq.ContentType = "application/json";
        var data = encoding.GetBytes(json);
        httpWReq.ContentLength = data.Length;

        using (var stream = httpWReq.GetRequestStream())
        {
          stream.Write(data, 0, data.Length);
        }

        var response = (HttpWebResponse)httpWReq.GetResponse();

        string jsonResult = new StreamReader(response.GetResponseStream()).ReadToEnd();
        if (typeof(T) == typeof(string))
        {
          jsonResult = "\"" + jsonResult + "\"";
        }

        T result = JsonConvert.DeserializeObject<T>(jsonResult);
        return result;
      }
      catch (Exception ex)
      {
        var e = ex;
        throw;
      }
    }
  }
}
