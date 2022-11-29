using Moq;
using NUnit.Framework;
using Stampin.Api.Business;
using Stampin.Api.Common;
using Stampin.Api.DataAccess;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Stampin.Api.Test
{
  public class Tests
  {
    TreeManager TreeManager;
    private Mock<ILogger<TreeManager>> testLogger;
    WeedManager WeedManager;
    private Mock<ILogger<WeedManager>> weedLogger;
    private Mock<IPlantContext> PlantC;

   [SetUp]
    public void Setup()
    {
      PlantC = new Mock<IPlantContext>();
      testLogger = new Mock<ILogger<TreeManager>>();
      TreeManager = new TreeManager(testLogger.Object, this.PlantC.Object);
      weedLogger = new Mock<ILogger<WeedManager>>();
      WeedManager = new WeedManager(weedLogger.Object, this.PlantC.Object);
    }

    [Test]
    public void GetTreesById()
    {
      var expected = new Response<Tree> { Successfull = true, Values = new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" } };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && expected.Values.Name == result.Trees["Id"][0].Name);
    }

    [Test]
    public void GetTreesByIdZero()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=0");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull &&  result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByIdString()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Id=F");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByIdSpelling()
    {
      var expected = new Response<Tree> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetTreesById(It.IsAny<int>())).Returns(expected);
      var result = TreeManager.GetTrees("Is=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 0);
    }

    [Test]
    public void GetTreesByFallColor()
    {
      var expected = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Zelkova" } } };
      this.PlantC.Setup(x => x.GetTreesWithFallColor()).Returns(expected);
      var result = TreeManager.GetTrees("FallColor=true");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Trees.Count == 1);
      Assert.IsTrue(result?.Trees["FallColor"].Count == 2 && result?.Trees["FallColor"][1].Name == expected.Values[1].Name);
    }

    [Test]
    public void GetTrees()
    {
      var fallTrees = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Zelkova" } } };
      var springTrees = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Pyrus calleryana (Bradford Pair)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var treeName = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var deciduous = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Pyrus calleryana (Bradford Pair)" }, new Tree { Conifer = false, Deciduous = true, FallColor = Color.Yellow, Id = 5, Name = "Malus (Apple)" } } };
      var conifers = new Response<List<Tree>> { Successfull = true, Values = new List<Tree> { new Tree { Conifer = true, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "bald cypress" } } };
      var treeId = new Response<Tree> { Successfull = true, Values = new Tree { Conifer = false, Deciduous = true, FallColor = Color.Red, Id = 1, Name = "Acer Rubrum (Red Maple)" } };
      this.PlantC.Setup(x => x.GetTreesWithFallColor()).Returns(fallTrees);
      this.PlantC.Setup(x => x.GetTreesWithSpringFlowers()).Returns(springTrees);
      this.PlantC.Setup(x => x.GetTreesById(1)).Returns(treeId);
      this.PlantC.Setup(x => x.GetTreesById(0)).Returns(treeId);
      this.PlantC.Setup(x => x.GetDeciduousTrees()).Returns(deciduous);
      this.PlantC.Setup(x => x.GetConiferisTrees()).Returns(conifers);
      this.PlantC.Setup(x => x.GetTreesByName("Malus(Apple)")).Returns(treeName);
      var result = TreeManager.GetTrees("Id=1&Name=Acer&Deciduous=false&Conifer=false&FallColor=true&SpringFlowers=true");
      Assert.IsTrue(result.Success.Successfull == false && result?.Trees.Count == 3);
      Assert.IsTrue(result?.Trees["FallColor"].Count == 2 && result?.Trees["FallColor"][1].Name != springTrees.Values[1].Name);
    }



    [Test]
    public void GetWeedsById()
    {
      var expected = new Response<Weed> { Successfull = true, Values = new Weed { OverallColor = Color.Green, Thorns = false, FlowerColor = Color.White, Id = 1, Name = "Malva Neglecta" } };
      this.PlantC.Setup(x => x.GetweedById(It.IsAny<int>())).Returns(expected);
      var result = WeedManager.GetWeeds("Id=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && expected.Values.Name == result.Weeds["Id"][0].Name);
    }

    [Test]
    public void GetWeedsByIdZero()
    {
      var expected = new Response<Weed> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetweedById(It.IsAny<int>())).Returns(expected);
      var result = WeedManager.GetWeeds("Id=0");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Weeds.Count == 0);
    }

    [Test]
    public void GetWeedsByIdString()
    {
      var expected = new Response<Weed> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetweedById(It.IsAny<int>())).Returns(expected);
      var result = WeedManager.GetWeeds("Id=F");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Weeds.Count == 0);
    }

    [Test]
    public void GetWeedByIdSpelling()
    {
      var expected = new Response<Weed> { Successfull = false, Values = null };
      this.PlantC.Setup(x => x.GetweedById(It.IsAny<int>())).Returns(expected);
      var result = WeedManager.GetWeeds("Is=1");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Weeds.Count == 0);
    }

    [Test]
    public void GetWeedsWithThorns()
    {
      var expected = new Response<List<Weed>> { Successfull = true, Values = new List<Weed>{ new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.Purple, Id = 2, Name = "Bull Thistle" }, new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.None, Id = 2, Name = "Musk Thistle" } } };
      this.PlantC.Setup(x => x.GetWeedsWithThorns()).Returns(expected);
      var result = WeedManager.GetWeeds("Thorns=true");
      Assert.IsTrue(expected.Successfull == result.Success.Successfull && result?.Weeds.Count == 1);
      Assert.IsTrue(result?.Weeds["Thorns"].Count == 2 && result?.Weeds["Thorns"][1].Name == expected.Values[1].Name);
    }

    [Test]
    public void GetWeeds()
    {
      var thornWeeds = new Response<List<Weed>> { Successfull = true, Values = new List<Weed> { new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.Purple, Id = 2, Name = "Bull Thistle" }, new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.None, Id = 2, Name = "Musk Thistle" } } };
      var flower = new Response<List<Weed>> { Successfull = true, Values = new List<Weed> { new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.Purple, Id = 2, Name = "Bull Thistle" }, new Weed { OverallColor = Color.Green, Thorns = false, FlowerColor = Color.White, Id = 2, Name = "morning glory" } } };
      var weedName = new Response<List<Weed>> { Successfull = true, Values = new List<Weed> { new Weed { OverallColor = Color.Green, Thorns = true, FlowerColor = Color.Purple, Id = 2, Name = "malva neglecta" }} };
      this.PlantC.Setup(x => x.GetWeedsWithThorns()).Returns(thornWeeds);
      this.PlantC.Setup(x => x.GetWeedsWithFlowerColor()).Returns(flower);
      this.PlantC.Setup(x => x.GetWeedsByName("malva neglecta")).Returns(weedName);
      var result = WeedManager.GetWeeds("Id=1&Name=malva neglecta&Thorns=true&FlowerColor=true&SpringFlowers=true");
      Assert.IsTrue(result.Success.Successfull == false && result?.Weeds.Count == 3);
      Assert.IsTrue(result?.Weeds["FlowerColor"].Count == 2 && result?.Weeds["Thorns"][1].Name == thornWeeds.Values[1].Name);
    }
  }
}