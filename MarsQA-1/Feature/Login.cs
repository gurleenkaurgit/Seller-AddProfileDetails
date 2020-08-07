using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public sealed class Login
    {
        [Given(@"I login to the website")]
        public void GivenILoginToTheWebsite()
        {
            Console.WriteLine("Login to Website");
        }
        [Then(@"I should be able to see login")]
        public void ThenIShouldBeAbleToSeeLogin()
        {
            Console.WriteLine("Logged in successfully");
        }


    }
}
