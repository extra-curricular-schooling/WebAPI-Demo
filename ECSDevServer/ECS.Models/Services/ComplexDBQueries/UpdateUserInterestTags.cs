using ECS.DTO;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace ECS.Models.Services.ComplexDBQueries
{
    public class UpdateUserInterestTags 
    {
        public HttpResponseMessage UpdateUserInterests(InterestTagsDTO userInterests)
        {
            try
            {
                using (var context = new ECSContext())
                {
                    var account = context.Accounts.Single(x => x.UserName == userInterests.username);
                    var accountTags = account.AccountTags;
                    foreach (var interest in accountTags.ToList())
                    {
                        if (!userInterests.interestTags.Contains(interest.TagName))
                        {
                            var tag = context.InterestTags.Single(x => x.TagName == interest.TagName);
                            account.AccountTags.Remove(tag);
                        }
                    }

                    foreach (var interest in userInterests.interestTags)
                    {
                        var tag = context.InterestTags.Single(x => x.TagName == interest);
                        if (!account.AccountTags.Contains(tag))
                        {
                            account.AccountTags.Add(tag);
                            tag.AccountUsername.Add(account);
                        }
                    }
                    context.SaveChanges();
                }
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Interest Tag Updated Successfully",
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                return new HttpResponseMessage
                {
                    ReasonPhrase = "Error has occurred",
                    StatusCode = HttpStatusCode.InternalServerError
                }; 
            }
        }
    }
}
