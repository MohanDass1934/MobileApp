using Microsoft.AspNetCore.Components;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Services
{
    public class HeaderService
    {
        public string Title { get; private set; } = "Dentest";
        public string? Subtitle { get; private set; }
        public bool ShowBack { get; private set; }
        public string? BackUrl { get; private set; }
        public Action? BackAction { get; private set; }
        public string HeaderColor { get; private set; } = "#ffffff";
        public string TextColor { get; private set; } = "#0b1b33";
        public RenderFragment? RightContent { get; private set; }

        public event Action? OnChange;

        public void Set(
            string title,
            string? subtitle = null,
            bool showBack = false,
            string? backUrl = null,
            Action? backAction = null,
            string headerColor = "#ffffff",
            string textColor = "#0b1b33",
            RenderFragment? rightContent = null)
        {
            Title = title;
            Subtitle = subtitle;
            ShowBack = showBack;
            BackUrl = backUrl;
            BackAction = backAction;
            HeaderColor = headerColor;
            TextColor = textColor;
            RightContent = rightContent;
            OnChange?.Invoke();
        }

        public void Reset()
        {
            Set("Dentest");
        }
    }
}