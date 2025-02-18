# 🌐 **Async Web Page Downloader**

[![Build](https://github.com/diaziker/EntainChallenge/actions/workflows/build.yml/badge.svg)](https://github.com/diaziker/EntainChallenge/actions/workflows/build.yml)  
[![Tests](https://github.com/diaziker/EntainChallenge/actions/workflows/tests.yml/badge.svg?branch=master)](https://github.com/diaziker/EntainChallenge/actions/workflows/tests.yml)

## 📝 **Description**
This is a **.NET 9** program that allows downloading multiple web pages asynchronously, handling retries and cancellations efficiently.

### **🔹 Features:**
✅ Simultaneous downloading of multiple URLs.  
✅ Cancellation handling with `CancellationToken`.  
✅ Detailed logging with **Serilog**.  
✅ Automatic retries on failures using `HttpClientService`.

---

## 🔎 **Usage Example**

Before running the application, configure the **URLs to download** in `appsettings.json`:

```json
{
  "Urls": [
    "https://example.com",
    "https://dotnet.microsoft.com",
    "https://github.com"
  ]
}
```

## 🚀 Technologies Used
- .NET 9.0
- C#
- xUnit for unit testing
- Moq for mocking in tests
- Serilog for logging

## 🛠️ **How to Run the Application**

### 🔹 1️⃣ Clone the Repository
```sh
git clone https://github.com/diaziker/EntainChallenge.git
cd ./EntainChallenge
```

### 🔹 2️⃣ Run the Application
Make sure you have .NET 9 SDK installed, then execute:

```sh
dotnet run --project ./AsynchronousWebPageDownload/src/AsyncWebPageDownloader.csproj
```