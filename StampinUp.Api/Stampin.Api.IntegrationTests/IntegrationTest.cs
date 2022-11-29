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
    private readonly string UpdateTreeAddr = "Tree/UpdateTrees";
    private readonly string Post = "POST";
    private readonly string Get = "GET";
    private readonly string Put = "PUT";
    private readonly string Delete = "DELETE";
    public void RunTests()
    {
      try
      {
        var getResult = this.GetTreeTest("Id=1&Name=Acer&Deciduous=false&Conifer=false&FallColor=true&SpringFlowers=true");
        var getZero = this.GetTreeTest("Id=0");
        var getFallTreesResult = this.GetTreeTest("FallColor=true");
        var getConifersResult = this.GetTreeTest("Conifer=true");
        var createResult = this.CreateTrees();
        var updateResult = this.UpdateTrees();
        var deleteResult = this.DeleteTrees();
        var success = getResult.Success.Successfull && createResult.Success.Successfull && updateResult.Success.Successfull && deleteResult.Success.Successfull;
      }
      catch(Exception ex)
      {
        var msg = "look at the exeption";
      }
    }

    public GetTreesResponse GetTreeTest(string args)
    {
      return this.Call<GetTreesResponse, string>(args, this.GetTreeAddr, this.Get);
    }

    public CreateTreesResponse CreateTrees()
    {
      CreateTreesRequest request = new CreateTreesRequest
      {
        Trees = new List<Tree>
        {
          new Tree
          {
              Height = "35 ft",
              Width = "20 ft",
             Conifer = true,
             Deciduous = true,
             FallColor = Color.Brown,
             SpringFlowers = false,
             Name = "Bald Cypress"
          },
          new Tree
          {
              Height = "25, ft",
              Width = "20 ft",
             Conifer = false,
             Deciduous = true,
             FallColor = Color.Red,
             SpringFlowers = false,
             Name = "Red Maple"
          },
        }
      };

      return this.Call<CreateTreesResponse, CreateTreesRequest>(request, this.CreateTreeAddr, this.Post);
    }

    public UpdateTreesResponse UpdateTrees()
    {
      UpdateTreesRequest request = new UpdateTreesRequest
      {
        Trees = new List<Tree>
        {
          new Tree
          {
            Id = 4,
              Height = "35 ft",
              Width = "20 ft",
             Conifer = true,
             Deciduous = true,
             FallColor = Color.None,
             SpringFlowers = false,
             Name = "Taxodium Distichum (Bald Cypress)"
          },
          new Tree
          {
            Id = 1,
              Height = "30 ft",
              Width = "20 ft",
             Conifer = false,
             Deciduous = true,
             FallColor = Color.Red,
             SpringFlowers = false,
             Name = "Acer Rubrum (Red Maple)"
          },
        }
      };

      return this.Call<UpdateTreesResponse, UpdateTreesRequest>(request, this.UpdateTreeAddr, this.Put);
    }
    public DeleteTreesResponse DeleteTrees()
    {
      DeleteTreeRequest request = new DeleteTreeRequest
      {
        Id = 4
      };

      return this.Call<DeleteTreesResponse, DeleteTreeRequest>(request, this.UpdateTreeAddr, this.Delete);
    }


    private T Call<T, TR>(TR request, string uri, string methodType)
    {
      try
      {
        var encoding = new ASCIIEncoding();
        HttpWebRequest httpWReq;
        if (methodType != this.Get)
        {
          httpWReq = (HttpWebRequest)WebRequest.Create(this.baseUri + uri);
          httpWReq.Method = methodType;
          httpWReq.ContentType = "application/json";
          string json = JsonConvert.SerializeObject(request);
          var data = encoding.GetBytes(json);
          httpWReq.ContentLength = data.Length;

          using (var stream = httpWReq.GetRequestStream())
          {
            stream.Write(data, 0, data.Length);
          }
        }
        else
        {
          httpWReq = (HttpWebRequest)WebRequest.Create(this.baseUri + uri + request);
          httpWReq.Method = methodType;
          httpWReq.ContentType = "application/json";
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
