using Lab5Web.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Lab5Web.Helpers
{
	public static class CollectionHelpers
	{
		public static IHtmlContent ExternalRenderCollections(this IHtmlHelper html, CashCollection[] collections)
		{
			var table = new System.Text.StringBuilder();

			foreach (var collection in collections)
			{
				if (collection != null)
				{
					table.Append("<tr>");
					table.AppendFormat("<td>{0}</td>", collection.RouteNumber);
					table.AppendFormat("<td>{0}</td>", collection.CollectorName);
					table.AppendFormat("<td>{0}</td>", collection.Amount);
					table.AppendFormat("<td>{0}</td>", collection.CollectionDateTime);
					table.AppendFormat("<td>{0}</td>", collection.IsCompleted ? "Да" : "Нет");
					table.AppendFormat("<td>{0}</td>", collection.Notes);
					table.Append("<td>");
					table.AppendFormat("<a href='/CashCollection/Edit/{0}'>Редактировать</a> | ", collection.RouteNumber);
					table.AppendFormat("<a href='/CashCollection/Details/{0}'>Просмотр</a>", collection.RouteNumber);
					table.Append("</td>");
					table.Append("</tr>");
				}
			}

			return new HtmlString(table.ToString());
		}
	}
}