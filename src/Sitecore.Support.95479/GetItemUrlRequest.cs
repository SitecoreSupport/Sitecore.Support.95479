using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceEditor.Speak.Server.Contexts;
using Sitecore.ExperienceEditor.Speak.Server.Requests;
using Sitecore.ExperienceEditor.Speak.Server.Responses;
using Sitecore.Globalization;
using Sitecore.Text;
using Sitecore.Web;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.Search
{
    public class GetItemUrlRequest : PipelineProcessorRequest<ValueItemContext>
    {
        public override PipelineProcessorResponseValue ProcessRequest()
        {
            string value = base.RequestContext.Value;
            Assert.IsNotNull(value, "Could not get item ID for requestArgs:{0}", new object[]
            {
                base.Args.Data
            });
            Item item = base.RequestContext.Item;
            Assert.IsNotNull(item, "Could not get Item for requestArgs:{0}", new object[]
            {
                base.Args.Data
            });
            string path = ID.IsID(value) ? value : Sitecore.Shell.Applications.WebEdit.Commands.Search.ParseForAttribute(value, "id");
            Language language;
            Item item2;
            if (Language.TryParse(base.RequestContext.Language, out language))
            {
                item2 = item.Database.GetItem(path, language);
            }
            else
            {
                item2 = item.Database.GetItem(path);
            }
            if (item2 != null)
            {
                string itemUrl = WebEditUtil.GetItemUrl(item2);
                return new PipelineProcessorResponseValue
                {
                    Value = new UrlString(itemUrl).GetUrl()
                };
            }
            return new PipelineProcessorResponseValue();
        }
    }
}