using System;
using System.Windows;
using System.Reflection;
using Microsoft.VisualBasic.ApplicationServices;

namespace SJB.MeritViewer.WPF.Application
  {
  class ApplicationEntry
    {
    [STAThread]
    public static void Main(String[] args)
      {
      SingleInstanceApplication singleinstanceapp = new SingleInstanceApplication();
      singleinstanceapp.Run(args);
      }
    }

  public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
    private System.Windows.Application app;

    public SingleInstanceApplication()
      { this.IsSingleInstance = true; }
    
    protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
      {
      app = new System.Windows.Application();
      WindowMain vw = new WindowMain();
      
      vw.Title = "MeritViewer v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

      app.Run(vw);
      return false;
      }
    
    protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
      {
      if (app.MainWindow.WindowState == WindowState.Minimized)
      app.MainWindow.WindowState = WindowState.Normal;

      app.MainWindow.Activate();
      eventArgs.BringToForeground = true;
      }
    }
  }