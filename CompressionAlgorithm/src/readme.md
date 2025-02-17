# 📦 String Compression Console App

## 📝 Description
This is a **.NET 9** console application that requests a string input and applies a compression algorithm to reduce its size.

### **Compression Examples:**
| Input   | Output   |
|---------|---------|
| `AA`    | `2A`    |
| `AAB`   | `2A1B`  |
| `AAABBCCCCDDABC` | `3A2B4C2D1A1B1C` |
| `CCCACABBDD` | `3C1A1C1A2B2D` |

## 🔎 **Possible Outputs**
The application can produce the following outputs:

| Output Type       | Description                                   |
|-------------------|-----------------------------------------------|
| **Compressed String** | The compressed version of the input string (e.g., `3A2B4C`). |
| **Invalid Input**     | If the input contains non-alphabetic characters, spaces, or is empty. |
---

## 🚀 **Technologies Used**
- **.NET 9.0**
- **C#**
- **xUnit** for unit testing
- **FluentAssertions** for expressive assertions

---

## 🛠️ **How to Run the Application**
### 🔹 1️⃣ Clone the Repository
```sh
git clone https://github.com/diaziker/EntainChallenge.git
cd ./EntainChallenge
```

### 🔹 2️⃣ Run the Application
Ensure you have **.NET 9** SDK installed, then run:

```sh
dotnet run --project ./CompressionAlgorithm/src/CompressionAlgorithm.csproj
```