# ⚙️ Mechanical Vibration & Damping Calculator (C# GUI)

This repository contains a modern Windows Desktop Application (GUI) built with **C# and Windows Forms (.NET)**. It transitions the mathematical core logic of SDOF (Single Degree of Freedom) system simulations from a standard command-line interface into an interactive, user-friendly desktop experience for engineers.

---

## 🚀 Features & Engineering Interface
The application allows engineers, researchers, or dynamicists to input core physical variables and receive instantaneous analytical feedback:
* **Interactive Inputs:** Custom text boxes for Mass ($m$ - kg), Spring Constant ($k$ - N/m), and Damping Coefficient ($c$ - Ns/m).
* **Automated Decision Engine:** Instantly evaluates the system's condition and classifies it into **Underdamped**, **Critically Damped**, or **Overdamped** regimes.
* **Modern Layout:** Structured with a clean corporate palette (Slate Blue/White), explicit labels, and an embedded custom padding results panel.

---

## 🛠️ Tech Stack & Software Architecture
* **Language:** C#
* **Framework:** .NET Core 8.0 / Windows Forms (WinForms)
* **Architecture:** Component-driven GUI Lifecycle with custom asynchronous Event-Handlers (`btnCalculate.Click`).