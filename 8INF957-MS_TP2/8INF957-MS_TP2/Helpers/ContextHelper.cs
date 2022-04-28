using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi;
using RestApi.Models;

namespace _8INF957_MS_TP2.Services
{
    public class ContextHelper
    {
        private TP2Context tp2Context;
        private Controller controller;

        public ContextHelper(Controller controller, TP2Context tp2Context)
        {
            this.controller = controller;
            this.tp2Context = tp2Context;
        }

        public int GetDoctorId()
        {
            return int.Parse(controller.HttpContext.User.Claims.Single(c => c.Type == "DoctorId").Value);
        }

        public Doctor? GetDoctor()
        {
            return tp2Context.Doctors.Find(GetDoctorId());
        }

        public ConfigurationIa GetConfigurationIa()
        {
            int doctorId = GetDoctorId();
            return tp2Context.Doctors.Include("ConfigurationIa").Single(d => d.Id == doctorId).ConfigurationIa;
        }

        public List<Patient> getContextPatients()
        {
            int doctorId = GetDoctorId();
            return tp2Context.Patients.Where(p => p.DoctorId == doctorId).ToList();
        }
    }
}
