using HealthMonitoring.Context;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Manager
{
    public class TypeOfEntryManager
    {
        private HealthMonitorContext _healthMonitorContext;
        public TypeOfEntryManager() { _healthMonitorContext = new HealthMonitorContext(); }

        public int AddType(TypeOfEntry typeOfEntry)
        {
            if(GetTypeOfEntryByName(typeOfEntry.Name) == null)
            {
                _healthMonitorContext.TypeOfEntrie.Add(typeOfEntry);
                return _healthMonitorContext.SaveChanges();

            }

            return 0;
            

            

        }

        public TypeOfEntry GetTypeOfEntryByName(string name)
        {
            TypeOfEntry typeOfEntry = _healthMonitorContext
                                        .TypeOfEntrie.Where(type => type.Name == name)
                                        .FirstOrDefault();
            return typeOfEntry;
        }

        public TypeOfEntry GetTypeOfEntryById(int id)
        {
            TypeOfEntry typeOfEntry = _healthMonitorContext
                            .TypeOfEntrie.Where(type => type.Id == id)
                            .FirstOrDefault();

            return typeOfEntry;

        }

        public List<TypeOfEntry> GetAllType()
        {

            List<TypeOfEntry> allTypes = _healthMonitorContext.TypeOfEntrie.ToList();

            return allTypes;

        }

        public int DeleteTypeById(int id)
        {
            TypeOfEntry typeToDelete = _healthMonitorContext
                                .TypeOfEntrie.Where(type => type.Id == id)
                                .FirstOrDefault();

            _healthMonitorContext.TypeOfEntrie.Remove(typeToDelete);

            return _healthMonitorContext.SaveChanges() ;
        }

        public List<SelectListItem> GetAllEntryTypeForDropDown()
        {           

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            selectListItems.Add(new SelectListItem() { Value ="0",Text="--Select--"});

            foreach (TypeOfEntry typeOfEntry in GetAllType())
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = typeOfEntry.Id.ToString();
                selectListItem.Text = typeOfEntry.Name;

                selectListItems.Add(selectListItem);

            }


            return selectListItems;
        }
    }
}