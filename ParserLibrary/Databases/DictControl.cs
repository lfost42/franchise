using System;
using System.Collections.Generic;
using ParserLibrary.Models;

namespace ParserLibrary.Databases
{
    public class DictControl
    {
        public static DictModel dmodel = new DictModel();

        //public static DictModel CreateDictModel(string csvFile)
        //{
        //    List<LocationModel> models = ParserControl.GetAllLocations(csvFile);

        //    foreach (LocationModel model in models)
        //    {
        //        dmodel.GlobalDict.Add(Int32.Parse(model.Id.ToString()), model);
        //    }

        //    return (dmodel);
        //}

        public static IDictionary<int, LocationModel> CreateDict(string csvFile)
        {
            List<LocationModel> models = ParserControl.GetAllLocations(csvFile);

            IDictionary<int, LocationModel> dict = new Dictionary<int, LocationModel>();

            foreach (LocationModel model in models)
            {
                dmodel.GlobalDict.Add(Int32.Parse(model.Id.ToString()), model);
                dict.Add(Int32.Parse(model.Id.ToString()), model);
            }

            return (dict);
        }

    }
}
