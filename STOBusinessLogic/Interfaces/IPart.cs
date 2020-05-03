using STOBusinessLogic.Binding_models;
using STOBusinessLogic.View_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.Interfaces
{
    public interface IPart
    {
        List<PartViewModel> Read(PartBindingModel model);
        void CreateOrUpdate(PartBindingModel model);
        void Delete(PartBindingModel model);
    }
}
