# Unity Project Folder Structure

This repository follows Unity Package Manager (UPM) conventions, organizing assets and scripts into clear and maintainable folders.

---

## 📁 Folder Structure

### **1. Assets**
This folder contains all the assets, scripts, and data required for the Unity project. Below is the breakdown of its subfolders:

#### **Animations**
- Contains all animation clips, controllers, and related assets used in the project.
- Used in runtime and thus located under `Runtime/Animations`.

#### **Data**
- Includes level data, particle system configurations, and other runtime data files.
- Subfolders:
  - **Levels**: Level-specific data.
  - **EzyGamers**: Custom data assets.
  - **Particle System**: Particle system presets.

#### **Prefabs**
- Contains reusable prefabs used in the project.
- Located under `Runtime/Prefabs`.

#### **Resources**
- Assets placed here are loaded dynamically at runtime using Unity’s `Resources.Load()` API.

#### **Scenes**
- Contains all Unity scenes for the project.
- Organized under `Runtime/Scenes`.

#### **Scripts**
- The main scripts for the project are divided into MVC architecture:
  - **Controllers**: Handles the logic and behavior.
  - **Models**: Represents the data structure.
  - **Views**: Manages the UI and game visuals.
- Runtime scripts are in `Runtime/Scripts/`.
- Editor-specific scripts (e.g., custom inspectors) should go in `Editor/Scripts/`.

#### **TextMesh Pro**
- Contains all assets and configurations for TextMesh Pro:
  - **Fonts, Shaders, Sprites**: For runtime usage under `Runtime/TextMesh Pro`.
  - **Documentation, Examples & Extras**: Can remain as references, not included in runtime builds.

#### **UI Prefab**
- Prefabs related to UI components, placed under `Runtime/UI/`.

---

### **2. Editor**
- Contains scripts and tools used exclusively in the Unity Editor.
- This includes custom inspectors, editor windows, and other utilities.

---

### **3. Runtime**
- The primary runtime folder, containing all assets, scripts, and prefabs required by the built application.

---

### **4. Tests**
- Contains unit and integration tests for the project.
- Organized under `Tests/` with proper testing frameworks (e.g., NUnit).

---

## 💡 Usage Guidelines

1. **Adding Assets**
   - Place assets in the appropriate `Runtime/` or `Editor/` folder based on their purpose.
   - Use `Resources` sparingly, only when dynamic loading is necessary.

2. **Scripts**
   - Follow MVC conventions when creating new scripts:
     - **Controller**: Game logic.
     - **Model**: Data structure.
     - **View**: UI or visuals.

3. **Testing**
   - Write unit tests for logic in the `Tests/` folder.
   - Use integration tests for gameplay or UI verification.

4. **UPM Compliance**
   - Ensure any new features follow the Unity Package Manager structure.

---

## 🛠️ Development Tools
- **Unity Version**: Specify the Unity version used in this project (e.g., Unity 2022.3.x).
- **Packages**: List key Unity packages (e.g., TextMesh Pro, URP, etc.).

---

## 📜 Licensing
Include licensing details for any third-party assets or packages used in the project.

---

Feel free to customize this README as your project evolves!
