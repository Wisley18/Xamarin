﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    public partial class AgendamentoView : ContentPage
    {

        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            ViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (msg) =>
            {
                var confirm = await DisplayAlert("Salvar agendamento", "Deseja mesmo enviar o agendamento?", "Sim", "Não");

                if (confirm)
                {
                    DisplayAlert("Agendamento",
                    string.Format(
@"Veículo: {0} 
Nome: {1}
Fone: {2}
E-mail: {3}
Data Agendamento: {4}
Hora Agendamento: {5}",
                    ViewModel.Agendamento.Veiculo.Nome,
                    ViewModel.Agendamento.Nome,
                    ViewModel.Agendamento.Fone,
                    ViewModel.Agendamento.Email,
                    ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyy"),
                    ViewModel.Agendamento.HoraAgendamento), "OK");
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }

    }
}