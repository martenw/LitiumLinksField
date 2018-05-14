using System.Collections.Generic;
using Litium.FieldFramework;
using Litium.FieldFramework.Converters;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime.DependencyInjection;
using Litium.Web.Administration;
using Litium.Web.Administration.FieldFramework;
using Newtonsoft.Json.Linq;

namespace Litium.Accelerator.FieldFramework
{
    internal class LinksAdministrationExtension : IAppExtension
    {
        public IEnumerable<string> ScriptFiles { get; } = new[]
        {
            "~/Site/Administration/fieldFramework/accelerator_linksEdit.js"
        };

        public IEnumerable<string> AngularModules { get; } = null;
        public IEnumerable<string> StylesheetFiles { get; } = null;
    }

    [Service(Name = "Links")]
    internal class LinksEditFieldTypeConverter : IEditFieldTypeConverter
    {
        public object ConvertFromEditValue(EditFieldTypeConverterArgs args, JToken item)
        {
            return new { };
        }

        public JToken ConvertToEditValue(EditFieldTypeConverterArgs args, object item)
        {
            return new JObject();
        }

        public object CreateOptionsModel()
        {
            return new TextOption();
        }

        public string EditControllerName { get; } = "accelerator_linksEdit";
        public string EditControllerTemplate { get; } = "~/Site/Administration/fieldFramework/LinksEdit.html";
        public string SettingsControllerName { get; } = null;
        public string SettingsControllerTemplate { get; } = null;
        public string EditComponentName => null;
        public string SettingsComponentName => null;
    }

    [Service(Name = "Links")]
    internal class LinksJsonFieldTypeConverter : IJsonFieldTypeConverter
    {
        public object ConvertFromJsonValue(JsonFieldTypeConverterArgs args, JToken item)
        {
            return new { };
        }

        public JToken ConvertToJsonValue(JsonFieldTypeConverterArgs args, object item)
        {
            return new JObject();
        }
    }

    public class LinksFieldTypeMetadata : FieldTypeMetadataBase
    {
        public override string Id => "Links";
        public override bool IsArray => false;

        public override IFieldType CreateInstance(IFieldDefinition fieldDefinition)
        {
            var item = new LinksFieldType();
            item.Init(fieldDefinition);
            return item;
        }

        public class LinksFieldType : FieldTypeBase
        {
            public override object GetValue(ICollection<FieldData> fieldDatas)
            {
                return null;
            }

            protected override ICollection<FieldData> PersistFieldDataInternal(object item)
            {
                return null;
            }
        }
    }
}