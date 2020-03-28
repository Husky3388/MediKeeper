using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediKeeper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediKeeper.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly MediKeeperItemContext _context;

        public IndexModel(MediKeeperItemContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> itemNameQuery = from m in _context.Item
                                            orderby m.ItemName
                                            select m.ItemName;

            var items = from m in _context.Item
                         select m;
            if (!string.IsNullOrEmpty(ItemName))
            {
                if (ButtonAction == "Filter")
                {
                    items = items
                        .Where(x => x.ItemName == ItemName);
                }
                else if (ButtonAction == "Max Costs")
                {
                    items = items
                        .ToList()
                        .GroupBy(x => x.ItemName,
                            (key, y) => y.OrderByDescending(x => x.Cost)
                            .First())
                        .Where(x => x.ItemName == ItemName)
                        .AsQueryable();
                }
            }
            if (ButtonAction == "Max Costs")
            {
                items = items
                    .ToList()
                    .GroupBy(x => x.ItemName,
                        (key, y) => y.OrderByDescending(x => x.Cost)
                        .First())
                    .AsQueryable();
            }


            ItemNames = new SelectList(await itemNameQuery.Distinct().ToListAsync());
            Item = await Task.FromResult(items.ToList());
        }

        public SelectList ItemNames { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ButtonAction { get; set; }
    }
}
