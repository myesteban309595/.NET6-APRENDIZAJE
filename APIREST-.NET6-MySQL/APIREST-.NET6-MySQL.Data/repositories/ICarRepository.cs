﻿using APIREST_.NET6_MySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIREST_.NET6_MySQL.Data.repositories
{
    // en esta interfaz se agregan los metodos que se van a implementar

    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetDetails(int id);
        Task<bool> InsertCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);

    }
}
