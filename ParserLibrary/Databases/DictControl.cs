using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ParserLibrary.Models;

namespace ParserLibrary.Databases
{
    public class DictControl
    {
        public static LocationModel locModel = new LocationModel();
        public static DictControl dictControl = new DictControl();
        public DictModel mainDict = new DictModel();

        //private static string csvFile = "TacoBell-US-AL.csv";

        public DictModel DictRecords(string csvFile)
        {
            List<LocationModel> models = ParserControl.GetAllLocations(csvFile);

            foreach (LocationModel model in models)
            {
                foreach (var key in mainDict.mainDict.Keys)
                {
                    mainDict.mainDict.Add(model.Id, model);
                }
            }
            return mainDict;
        }

        public List<LocationModel> DictToModels(DictModel dict)
        {
            LocationModel location = new LocationModel();
            List<LocationModel> locations = new List<LocationModel>();

            foreach (var key in dict.mainDict.Keys)
            {
                dict.mainDict[key].Id = location.Id;
                dict.mainDict[key].GeoPoint.Latitude = location.GeoPoint.Latitude;
                dict.mainDict[key].GeoPoint.Longitude = location.GeoPoint.Longitude;
                dict.mainDict[key].Name = location.Name;
            }
            return locations;
        }

        public LocationModel DictToModel(DictModel dict, int id)
        {
            var locModel = dict.mainDict[id];
            return locModel;
        }

        public DictModel ModelsToDict(List<LocationModel> locations)
        {
            foreach (var location in locations)
            {
                mainDict.mainDict.Add(location.Id, location);
            }
            return mainDict;
        }

        //CREATE
        public DictModel AddLocation(DictModel dict, LocationModel location)
        {
            var maxKey = dict.mainDict.Keys.Max();
            dict.mainDict.Add(maxKey+1, location);
            return mainDict;
        }

        //READ
        public LocationModel ViewLocation(DictModel dict, int id)
        {
            var tempDict =  dict.mainDict[id];
            return tempDict;
        }

        //UPDATE
        public DictModel EditLocation(DictModel dict, int id, LocationModel model)
        {
            model.Id = dict.mainDict[id].Id;
            model.GeoPoint.Latitude = dict.mainDict[id].GeoPoint.Latitude;
            model.GeoPoint.Longitude = dict.mainDict[id].GeoPoint.Longitude;
            model.Name = dict.mainDict[id].Name;
            return dict;
        }

        //DELETE
        public DictModel DeleteLocation(DictModel dict, int id)
        {
            dict.mainDict.Remove(id);
            return dict;
        }

        public string DictToJson(DictModel dict)
        {
            string toString = "";

            foreach (int key in dict.mainDict.Keys)
            {
                toString += $"{key} {dict.mainDict[key].GeoPoint.Latitude} {dict.mainDict[key].GeoPoint.Longitude} {dict.mainDict[key].Name}\n";
            }
            return toString;

        }

    }
}
