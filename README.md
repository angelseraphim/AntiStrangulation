# AntiStrangulation

![SCP:SL Plugin](https://img.shields.io/badge/SCP--SL-Plugin-blue.svg)
![Language: C#](https://img.shields.io/badge/language-C%23-blue.svg)
![Downloads](https://img.shields.io/github/downloads/angelseraphim/AntiStrangulation/total?label=Downloads&color=333333&style=for-the-badge)

---

**AntiStrangulation** is a plugin for SCP: Secret Laboratory that allows advanced control over SCP-3114’s strangulation mechanic and its auto-spawn behavior, especially during Halloween events.

---

## Features

- **Disable Strangulation:** Prevent SCP-3114 from strangling players.
- **Flexible Auto-Spawn Control:**  
  - Prevents SCP-3114 from spawning automatically during Halloween (if configured).
  - Allows forced auto-spawn outside of Halloween based on config.

---

## Configuration (`config.yml`)

```yaml
disable_strangulation: true
disable_auto_spawn: false
```
disable_strangulation
true — SCP-3114 cannot strangle players.
false — Strangulation is allowed.

disable_auto_spawn
false — If it’s Halloween, SCP-3114 will NOT auto-spawn.
true — SCP-3114 will always auto-spawn regardless of Halloween.

Installation
Download the latest release from the Releases page.
Place the DLL file in LabApi directory.
Configure config.yml as needed.
