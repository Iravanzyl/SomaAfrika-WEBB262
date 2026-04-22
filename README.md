\# 📚 SomaAfrika — University Textbook Exchange Platform



!\[SomaAfrika Logo](SomaAfrica/wwwroot/images/SomaAfrica\_WEBB262\_SS1\_Logo\_No.png)



> Connecting students who need textbooks with those selling them — affordably, safely, and with community trust.



\---



\## 📖 Project Description



SomaAfrika is a university textbook exchange platform built for African higher education students. 

It enables students to buy, sell, and exchange prescribed textbooks within a trusted campus community.



Inspired by real African ed-tech innovations like \*\*Rebooked\*\* (South Africa) and \*\*Bookbay\*\* (Nigeria), 

SomaAfrika addresses the financial barriers students face when accessing prescribed textbooks — 

with some costing over R1000.



\### Key Features

\- 🔐 Secure registration and login with university email

\- 📚 Post, browse, edit and delete textbook listings

\- 🔍 Multi-field search by title, author, ISBN or course code

\- 🏷️ Filter by price range, condition and campus

\- 🤝 Make and respond to offers

\- 💵 Cash on Meetup payment option

\- ⭐ Community Trust Score based on reviews

\- 📊 Personal dashboard — listings, offers, transactions, reviews

\- 🌍 English / isiZulu language toggle

\- 📢 Wanted ads for books you are looking for



\---



\## 👥 Team



| Person | Role | Sections |

|---|---|---|

| Person 1 | Foundation \& Security | Database, Identity, Architecture |

| Person 2 | Core Features | CRUD, Business Logic |

| Person 3 (Ira) | Frontend, Search \& Africanisation | Search, Dashboard, UI, Africanisation, GitHub, Docs |



\---



\## 🛠️ Technologies Used



| Technology | Purpose |

|---|---|

| Blazor Server (.NET 8) | UI framework |

| ASP.NET Core | Web framework |

| C# | Programming language |

| Entity Framework Core 8 | Database ORM |

| SQL Server (LocalDB) | Database |

| ASP.NET Identity | Authentication \& authorisation |

| Bootstrap 5 | Responsive styling |

| GitHub | Version control |



\---



\## ⚙️ Setup Instructions



\### Prerequisites

\- Visual Studio 2022+

\- .NET 8 SDK

\- SQL Server LocalDB



\### Steps



1\. \*\*Clone the repository:\*\*

git clone https://github.com/Iravanzyl/SomaAfrika-WEBB262.git



2\. \*\*Open the solution in Visual Studio:\*\*

&#x20;  - Open `SomaAfrica.csproj`



3\. \*\*Configure the database connection:\*\*

&#x20;  - Open `appsettings.json`

&#x20;  - Update the `DefaultConnection` string if needed



4\. \*\*Run migrations:\*\*

&#x20;  - Open Package Manager Console

&#x20;  - Run `Update-Database`



5\. \*\*Run the application:\*\*

&#x20;  - Press `Ctrl + F5`

&#x20;  - Register a new account to get started



\---



\## 🗄️ Database Design



The application uses a normalised relational database with the following entities:



\- \*\*ApplicationUser\*\* — registered students with Trust Score

\- \*\*Textbook\*\* — book details (title, author, ISBN, subject)

\- \*\*Listing\*\* — a textbook for sale (price, condition, campus)

\- \*\*Offer\*\* — a buyer's offer on a listing

\- \*\*Transaction\*\* — created when an offer is accepted

\- \*\*Review\*\* — left after a completed transaction

\- \*\*WantedAd\*\* — a request for a specific textbook



\### Relationships

\- User → Listings (one to many)

\- Textbook → Listings (one to many)

\- Listing → Offers (one to many)

\- Offer → Transaction (one to one)

\- Transaction → Reviews (one to many)

\- User → WantedAds (one to many)



\---



\## 🌍 Africanisation Features



| Feature | Implementation |

|---|---|

| Community Trust Score | Calculated from received reviews, displayed on listings and dashboard |

| Cash on Meetup | Default payment method, shown on all listing and offer pages |

| Language Toggle | Full English / isiZulu interface toggle in the navigation |

| Inclusive Terminology | Campus-focused language throughout the platform |



\---



\## 📸 Screenshots



> Add screenshots of your running application here



\---



\## 📁 Project Structure

SomaAfrica/

Components/

Pages/

Listings/       — Browse, Detail, CreateEdit

Dashboard/      — User dashboard

WantedAds/      — Wanted ads list and form

Reviews/        — Leave a review

Layout/           — NavMenu, MainLayout

Data/               — DbContext, ApplicationUser

Models/             — All entity models

Services/           — SearchService, DashboardService, LanguageService

wwwroot/            — Static files, images, CSS



\---



\## 📄 Assignment Information



\- \*\*Module:\*\* Web Development 2B (WEBB262)

\- \*\*Assessment:\*\* SS2

\- \*\*Institution:\*\* STADIO

\- \*\*Year:\*\* 2026

