﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels
{
    public class SectionViewModel : INamedEntity, IOrderedEntity
    {
        public SectionViewModel()
        {
            ChildSections = new List<SectionViewModel>();
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public List<SectionViewModel> ChildSections { get; set; }
        public SectionViewModel ParentSection { get; set; }
    }
}
