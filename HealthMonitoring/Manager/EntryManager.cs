using HealthMonitoring.Context;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Manager
{
    public class EntryManager
    {
        public HealthMonitorContext _healthMonitorContext;

        public EntryManager() { _healthMonitorContext = new HealthMonitorContext(); }


        public int AddEntry(Entry entry)
        {
            EntryFilter entryFilter = new EntryFilter();

            entryFilter.UserId = entry.UserId;
            entryFilter.TypeOfEntry = entry.TypeOfEntry;
            entryFilter.FromeDate = entry.DateOfEntry;
            entryFilter.ToDate = entry.DateOfEntry;

            Entry entryToFind = GetEntryByFilter(entryFilter).FirstOrDefault();

            if(entryToFind != null)
            {
                _healthMonitorContext.Entry.Remove(entryToFind);
                _healthMonitorContext.SaveChanges();

                entryToFind.Value = entry.Value;
                _healthMonitorContext.Entry.Add(entryToFind);

                return _healthMonitorContext.SaveChanges();

            }


            _healthMonitorContext.Entry.Add(entry);

            return _healthMonitorContext.SaveChanges();
        }

        public List<Entry> GetAllEntry()
        {
            List<Entry> allEntry = _healthMonitorContext.Entry.ToList();


            return allEntry;

        }

        public List<Entry> GetEntryByFilter(EntryFilter entryFilter)
        {
            List<Entry> entrys = _healthMonitorContext.Entry
                                 .Where(entry => entry.UserId == entryFilter.UserId &&
                                        entry.TypeOfEntry == entryFilter.TypeOfEntry &&
                                        entry.DateOfEntry >= entryFilter.FromeDate &&
                                        entry.DateOfEntry <= entryFilter.ToDate)
                                 .OrderBy(entity => entity.DateOfEntry)
                                 .ToList();

            return entrys;

        }

        
    }
}