# Mushroom Clicker 🍄

Mushroom Clicker is a 2D incremental (idle) clicker built with Unity and C#.  
A compact project featuring a modular upgrade system and local JSON-based persistence.

---

## Key features ✨

- Click-based progression with both active (per-click) and passive (per-second) income.
- Two upgrade systems:
  - Click Upgrades — increase points per click.
  - Passive Upgrades — increase points per second.
- Modular components for upgrades (Upgrade and ClickUpgrade) that are easy to configure from the Inspector.
- Local JSON save/load (reliable persistence across sessions).
- UI using TextMesh Pro and Unity UI components.
- Built with Universal Render Pipeline (URP) assets included.

---

## Tech stack & tools ⚙️

- Unity (URP)
- C#
- TextMesh Pro
- Unity Input System
- JSON-based save system (Application.persistentDataPath)

---

## Quick start — run locally

1. Clone the repository:
   git clone https://github.com/Sibefax/Mushroom-Clicker.git
2. Open Unity Hub, add the project folder, and open the project.
3. Let Unity resolve any packages if prompted.
4. Open the main scene in Assets/Scenes and press Play.

Also you can download build in releases.

---

## Project layout (high level)

- Assets/
  - Scripts/
    - Upgrade.cs — passive upgrade component: cost, level, income, UI.
    - ClickUpgrade.cs — click upgrade component: cost, bonus, purchase state, UI.
    - StoreManager.cs — main game loop: balances, applying purchases, UI updates.
    - SaveManager.cs — loads/saves game state on Start / focus change / quit.
    - SaveSystem.cs — JSON save/load implementation.
    - SaveData.cs — serializable save data classes.
  - Scenes/ — Unity scenes
  - Prefabs/, Sprites/, Animations/, Settings/ — project assets
  - InputSystem_Actions.inputactions — input mappings included

---

## Save system details 💾

- Save path: <persistentDataPath>/save.json
- Save format: JSON (BalanceSaveData)
- Persists:
  - exact balance (double)
  - list of passive upgrades with levels
  - list of click upgrades with purchase state
- Save triggers:
  - on application quit
  - on application losing focus
- Load happens on Start

---

## Design highlights

- Clear separation between UI, data and game logic.
- Upgrade behaviour is encapsulated in MonoBehaviour components for quick iteration in the Editor.
- Save implementation is simple and replaceable with alternative backends if needed.
- UI uses TextMesh Pro for crisp text rendering.

---

## Credits & assets

- Mushroom pack by peterfield2006 — https://opengameart.org/content/mushroom-pixel-art-pack-32x32-free-game-assets  
- Forest Background — https://qdanp.itch.io/forest-stage-escenario-bosque  
- UI Pack — https://crusenho.itch.io/complete-ui-essential-pack (licensed under CC BY 4.0)

Please ensure to keep required attribution text from the asset authors if any license demands it.

---

## License

This project is licensed under the MIT License — see the LICENSE file for details.
