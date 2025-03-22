# Windows Config Toolkit

A modular, user-friendly Windows Configuration Tool built in PowerShell + WPF (.NET/C#), designed to simplify common system tweaks, registry changes, service management, and system configuration tasks.

This project is a personal toolkit intended for local use, with plans for future polishing and packaging for broader distribution.

## 🚀 Features

- 🧩 Modular System Design (Registry Tweaks, Startup Manager, Services Manager, etc.)
- ✅ Toggle-based registry edits with real-time feedback
- 📂 Clean, organized GUI with sidebar navigation
- 🛠 System tools like Restore Point Creator and Quick Command Runner
- 🧪 Focus on safety-first, user-confirmed configuration management

## 📐 Architecture

- **.NET 6 WPF Application (C#)**
- PowerShell compatibility planned for backend extensibility
- MVVM-inspired modular layout
- Clean XAML UI components + dynamic UserControl loading

## 📋 Project Structure

```
/Modules/
    RegistryTweaks.xaml
    StartupManager.xaml
    ServicesManager.xaml
    SystemTweaks.xaml
    SystemRestore.xaml
    CommandRunner.xaml

/Themes/
    AppStyles.xaml

MainWindow.xaml + MainWindow.xaml.cs
App.xaml
README.md
ROADMAP.md
```

## 📌 Current Status

✅ Core framework complete  
✅ Core modules implemented  
🧪 Testing in progress  
✨ UI polish and packaging pending

## 🛣 Roadmap

Please refer to the [ROADMAP.md](./ROADMAP.md) file for a full breakdown of:
- Remaining tasks
- Phase plans
- Ideas for future improvements

## 📝 Usage

1. Clone the repo.
2. Open in **Visual Studio**.
3. Build and run.
4. Optionally run as **Administrator** to unlock all functionality.

> ⚠ Some tweaks (e.g., Registry or Service changes) require **elevated permissions**.

## 📦 Packaging Plan (Upcoming)

- Improved GUI layout
- ZIP-based distribution
- Optional installer script
- Light settings/profile support

## 📫 Feedback or Ideas?

This is a personal dev tool, but ideas are welcome! Check the Roadmap for feature proposals and add your own if contributing in the future.
