using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TradeTeq.Domain;
using TradeTeq.Repository;
using static System.DateTime;

namespace TradeTeq.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Guille", InsightType.Comment, "Author1",true, "03-15-2020", "content", "source")]
        [TestCase("Guille", InsightType.MediaCoverage, "Sheakspeare", true, "03-24-2020", "content", null)]
        [TestCase(null, InsightType.Event, "Platon",true, "02 -03-2020", "content", null)]
        public void TestCreateInsight(string title, InsightType type, string author , bool activeFlag, DateTime datePublished, string content, string  imageSource )
        {
            var insight = new Insight(title, type, datePublished, author,activeFlag, content, imageSource);
            Assert.AreEqual(insight.Title, title);
            Assert.AreEqual(insight.Type, type);
            Assert.AreEqual(insight.Author, author);
            Assert.AreEqual(insight.DatePublished, datePublished);
            Assert.AreEqual(insight.Content, content);
            Assert.AreEqual(insight.ImageSource, imageSource);
        }

        [Test]
        public void TestCreateInsightWithNoParams()
        {
            var insight = new Insight();
            Assert.AreEqual(insight.GetType(), typeof(Insight));
        }

    }
}