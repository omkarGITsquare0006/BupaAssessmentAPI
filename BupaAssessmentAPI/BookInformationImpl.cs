using System.IO;
using BupaAssessmentAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;

namespace BupaAssessmentAPI
{
    public class BookInformationImpl : IBook
    {
        static HttpClient client = new HttpClient();
        public const string BaseUrl = "https://digitalcodingtest.bupa.com.au/api/v1/bookowners";
        //public const string BaseUrl = null;

        public async Task<Dictionary<string, List<string>>> GetBooks()
        {
            List<BookAuth> bookAuthor = null;
            
            HttpResponseMessage response = await client.GetAsync(BaseUrl);
            if (response.IsSuccessStatusCode)
            {
                bookAuthor = await response.Content.ReadAsAsync<List<BookAuth>>();
            }
            if (!response.IsSuccessStatusCode || bookAuthor == null) return null;
            return FetchBooks(bookAuthor);
        }

        public Dictionary<string, List<string>> FetchBooks(List<BookAuth> bookAuthor)
        {
            Dictionary<string, List<string>> bookDict = new Dictionary<string, List<string>>();
            foreach (var author in bookAuthor)
            {
                if (author.age < 18)
                {
                    if (!bookDict.TryGetValue("child", out List<string> clist))
                    {
                        clist = new List<string>();
                        bookDict["child"] = clist;
                    }
                    clist.Add(author.name);
                }
                else
                {
                    if (!bookDict.TryGetValue("adult", out List<string> aList))
                    {
                        aList = new List<string>();
                        bookDict["adult"] = aList;
                    }
                    aList.Add(author.name);
                }
            }
            return bookDict;
        }
    }
}
