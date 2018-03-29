﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {
        

        public ListagemView()
        {
            InitializeComponent();
        }

        //private void ListViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var veiculo = (Veiculo)e.Item;

        //    Navigation.PushAsync(new  DetalheView(veiculo));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeicuoSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
