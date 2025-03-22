# 🛣 Windows Config Toolkit – Roadmap

A structured overview of remaining development tasks, future enhancements, and polish goals.

---

## ✅ Completed

- Core Framework with dynamic module loader
- Modules:
  - Registry Tweaks (toggleable)
  - Startup Manager
  - Services Manager
  - System Tweaks
  - Restore Point Creator
  - Command Runner Panel
- Working sidebar navigation + statusbar
- Toggle-based registry logic
- Base UI scaffolding

---

## 🧪 Phase 5: Testing and Debugging

- [ ] Test each module independently (preferably in a VM or with dummy registry entries)
- [ ] Add safety confirmation dialogs for destructive actions
- [ ] Add proper error handling with fallback messages
- [ ] Add optional logging/output pane

---

## ✨ Phase 6: Polish & Packaging

- [ ] Improve UI styling and layout responsiveness
- [ ] Add theme consistency (fonts, margins, spacing)
- [ ] Create `Help` module or tab with usage docs
- [ ] Create bundled ZIP or installer (possibly with launch shortcut)
- [ ] Add icons or glyphs to sidebar and buttons
- [ ] Review accessibility and keyboard navigation

---

## 📤 Phase 7: Optional Distribution Features

- [ ] Dark Mode toggle / UI Themes
- [ ] Exportable tweak profiles or configuration sets
- [ ] Export logs or changes to file
- [ ] Custom settings for default behavior
- [ ] Lightweight installer creation (e.g., InnoSetup or PowerShell)

---

## 💡 Ideas for Future

- Profile-specific tweaks (Gaming Mode, Developer Mode)
- PowerShell backend runner for each module
- System Info Dashboard module
- Backup/Restore Registry snapshot tool
- App Whitelisting/Blacklisting tool
- Scheduled Task manager
- Auto-detect common system health issues (event logs, etc.)

---

## 📎 Notes

You can extend this file into task checklists or link issues for agile-style tracking if desired.
