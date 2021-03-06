﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using Dicom;

namespace lectorDCM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Paciente> pacientes = new List<Paciente>();
            List<Plan> planes = new List<Plan>();
            var archivos = Directory.GetFiles(@"D:\Cosas pasar\Pablo Trabajo\nueva carpeta", "*.dcm", SearchOption.AllDirectories);
            
            foreach (string archivo in archivos)
            {
                if (Plan.ObtenerSOPClassUID(DicomFile.Open(archivo))==SOPClassUID.RTPlanStorage)
                {
                    Plan plan = new Plan(archivo, pacientes);
                    //pacientes.Add(plan.Paciente);
                    planes.Add(plan);
                    Console.WriteLine("Se ha agregado 1 plan: " + plan.PlanLabel + " del paciente: " + plan.Paciente.Nombre);
                }
            }
            Console.WriteLine("El total de planes encontrado es: " + planes.Count.ToString());
            Console.WriteLine("Se analizaron " + archivos.Length.ToString() + " archivos y se demoró " + sw.Elapsed.ToString());
            Console.ReadLine();
        }
    }
}
