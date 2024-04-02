using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Extension
{
    public static class Helper
    {
        public static string NumberFormat(decimal m)
        {
            return Math.Ceiling(m).ToString("N", new CultureInfo("vi-VN")).Replace(",00", "");
        }
        public static List<Setting> ListStatep()
        {
            List<Setting> list = new List<Setting>
            {
                new Setting {Value = "No", DisplayName = "Không"},
                new Setting {Value = "Hot", DisplayName = "Hot"},
                new Setting {Value = "New", DisplayName = "New"},
                new Setting {Value = "Sale", DisplayName = "Sale"},
                new Setting {Value = "Sold out", DisplayName = "Sold out"},
            };
            return list;
        }
        public static List<Setting> ListAvilability()
        {
            List<Setting> list = new List<Setting>
            {
                new Setting {Value = "Còn hàng", DisplayName = "Còn hàng"},
                new Setting {Value = "Hết hàng", DisplayName = "Hết hàng"},
            };
            return list;
        }
        public static List<SortModel> ListSortProduct()
        {
            List<SortModel> list = new List<SortModel>
            {
                new SortModel {Id = 0, DisplayName = "Mặc định"},
                new SortModel {Id = 1, DisplayName = "Giá(từ thấp đến cao)"},
                new SortModel {Id = 2, DisplayName = "Giá(từ cao đến thấp)"},
                new SortModel {Id = 3, DisplayName = "Tên sản phẩm(Từ A-Z)"},
                new SortModel {Id = 4, DisplayName = "Tên sản phẩm(Từ Z-A)"},
            };
            return list;
        }
        public static string RandomCode()
        {
            string base64Guid = Guid.NewGuid().ToString("N");
            var stringRanDom = base64Guid.Substring(0, 12);
            return stringRanDom.ToString();
        }
        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
                stringBuilder.Replace(" ", "");
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}
