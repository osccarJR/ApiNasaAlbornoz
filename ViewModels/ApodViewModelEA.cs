﻿using ApiNasaAlbornoz.Models;
using ApiNasaAlbornoz.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiNasaAlbornoz.ViewModels
{
    public class ApodViewModelEA : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ApodViewModelEA()
        {
            ChosenDate = DateTime.Now;
        }
        private DateTime dateTime;
        public DateTime ChosenDate
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    NotifyPropertyChanged();
                }
                _ = GetPictureOfTheDay(dateTime);
            }


        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri imageUri;
        public Uri ImageURI
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string didactic;
        public string Didactic
        {
            get { return didactic; }
            set
            {
                if (didactic != value)
                {
                    didactic = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ApodServiceEA service;
        public ApodServiceEA Service
        {
            get
            {
                if (service == null)
                {
                    service = new ApodServiceEA();
                }
                return service;
            }
        }
        private async Task GetPictureOfTheDay(DateTime day)
        {
            ApodEA dto = await Service.GetImage(day);
            if (dto == null)
            {
                ImageURI = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontradoefecto-falla_8024-5.jpg");
                Didactic = "";
                Title = "Intenta con otra fecha";
            }
            else
            {
                ImageURI = new Uri(dto.hdurl);
                Didactic = dto.explanation;
                Title = dto.title;
            }
        }

    }
}