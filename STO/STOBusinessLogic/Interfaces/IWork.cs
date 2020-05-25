using STOBusinessLogic.Binding_models;
using STOBusinessLogic.View_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.Interfaces
{
    public interface IWork
    {
        List<WorkViewModel> Read(WorkBindingModel model);
        void CreateOrUpdate(WorkBindingModel model);
        void Delete(WorkBindingModel model);
    }
}
