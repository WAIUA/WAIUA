﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using FontAwesome6;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WAIUA.Helpers;
using WAIUA.Objects;
using WAIUA.Views;
using static WAIUA.Helpers.Login;

namespace WAIUA.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    public delegate void EventAction();

    [ObservableProperty] private int _countdownTime = 20;
    [ObservableProperty] private DispatcherTimer _countTimer;
    [ObservableProperty] private List<Player> _playerList;
    [ObservableProperty] private string _refreshTime = "-";

    public event EventAction GoMatchEvent;

    public HomeViewModel()
    {
        _countTimer = new DispatcherTimer();
        _countTimer.Tick += UpdateTimersAsync;
        _countTimer.Interval = new TimeSpan(0, 0, 1);
    }

    [ICommand]
    private async Task LoadNowAsync()
    {
        CountdownTime = 20;
        await UpdateChecksAsync().ConfigureAwait(false);
    }

    [ICommand]
    private async Task PassiveLoadAsync()
    {
        if (!_countTimer.IsEnabled)
        {
            _countTimer.Start();
            await UpdateChecksAsync().ConfigureAwait(false);
        }
        
    }

    [ICommand]
    private Task StopPassiveLoadAsync()
    {
        CountTimer?.Stop();
        RefreshTime = "-";
        CountdownTime = 20;
        return Task.CompletedTask;
    }


    private async void UpdateTimersAsync(object sender, EventArgs e)
    {
        RefreshTime = CountdownTime + "s";
        if (CountdownTime == 0)
        {
            CountdownTime = 15;
            await UpdateChecksAsync().ConfigureAwait(false);
        }

        CountdownTime--;
    }


    [ICommand]
    private async Task UpdateChecksAsync()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Home.ValorantStatus.Icon = EFontAwesomeIcon.Solid_Question;
            Home.ValorantStatus.Foreground = new SolidColorBrush(Color.FromRgb(0, 126, 249));
            Home.AccountStatus.Icon = EFontAwesomeIcon.Solid_Question;
            Home.AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(0, 126, 249));
            Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Question;
            Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(0, 126, 249));
        });

        if (await Checks.CheckLocalAsync().ConfigureAwait(false))
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Home.ValorantStatus.Icon = EFontAwesomeIcon.Solid_Check;
                Home.ValorantStatus.Foreground = new SolidColorBrush(Color.FromRgb(50, 226, 178));
            });
            if (await Checks.CheckLoginAsync().ConfigureAwait(false))
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Home.AccountStatus.Icon = EFontAwesomeIcon.Solid_Check;
                    Home.AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(50, 226, 178));
                });
                if (await Checks.CheckMatchAsync().ConfigureAwait(false))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Check;
                        Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(50, 226, 178));
                    });
                    CountTimer?.Stop();
                    GoMatchEvent?.Invoke();
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                        Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                    });
                    await GetPartyPlayerInfoAsync().ConfigureAwait(false);
                }
            }
            else
            {
                await LocalLoginAsync().ConfigureAwait(false);
                await LocalRegionAsync().ConfigureAwait(false);
                if (await Checks.CheckLoginAsync().ConfigureAwait(false))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Home.AccountStatus.Icon = EFontAwesomeIcon.Solid_Check;
                        Home.AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(50, 226, 178));
                    });
                    if (await Checks.CheckMatchAsync().ConfigureAwait(false))
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Check;
                            Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(50, 226, 178));
                        });
                        CountTimer?.Stop();
                        GoMatchEvent?.Invoke();
                    }
                    else
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                            Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                        });
                        await GetPartyPlayerInfoAsync().ConfigureAwait(false);
                    }
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Home.AccountStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                        Home.AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                        Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                        Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                    });
                }
            }
        }
        else
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Home.ValorantStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                Home.ValorantStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                Home.AccountStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                Home.AccountStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
                Home.MatchStatus.Icon = EFontAwesomeIcon.Solid_Xmark;
                Home.MatchStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 70, 84));
            });
        }
    }

    [ICommand]
    private async Task GetPartyPlayerInfoAsync()
    {
        try
        {
            LiveMatch newLiveMatch = new();
            if (await newLiveMatch.CheckAndSetPartyIdAsync().ConfigureAwait(false)) PlayerList = await newLiveMatch.PartyOutputAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
            // ignored
        }

        GC.Collect();
    }
}