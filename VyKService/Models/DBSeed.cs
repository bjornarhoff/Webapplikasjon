using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VyKService.Models
{
    public static class DbSeed
    {
        public static void DbInit(IServiceScope serviceScope)
        {

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DB>();
            dbContext.Database.EnsureCreated();
            if (!dbContext.QA.Any())
            {
                var faq = new QA[]
                {
                    new QA
                    {
                        Question = "Hvordan kjøper jeg billett?",
                        Answer = "På vy.no får du kjøpt de fleste billetter ved å bruke reiseplanleggeren. Reiser du på Østlandet og i Hordaland, kan du på visse strekninger kjøpe 7 og 30 dagers elektronisk periodebillett på vy.no. Reisende i Rogaland kan kjøpe elektronisk periodebillett i Vy-appen eller periodebillett på reisekort hos Kolumbus. En periodebillett med setereservasjon kan kun kjøpes i Vy-appen.",
                        Votes = 2

                    },
                    new QA
                    {
                        Question = "Hvem kan få rabatt?",
                        Answer = "Vi tilbyr rabatterte priser til studenter, honnør og barn. Dette er et valg under kjøp av billett.",
                        Votes = 7
                    },
                    new QA
                    {
                        Question = "Hva skjer hvis jeg ikke rekker toget?",
                        Answer = "Enkeltbilletter er gyldig til angitt avgang, det vil si at du ikke kan benytte billetten på andre avganger. Du må dermed kjøpe en ny billett hvis du vil reise med neste avgang. Dersom du bruker Vy-appen til å kjøpe Ruter-billett, er det Ruters bestemmelser for gyldighetstid som gjelder.",
                        Votes = 4

                    },
                    new QA
                    {
                        Question = "Hvordan får jeg tilsendt kvittering på mail?",
                        Answer = "Etter du har kjøpt billett, vil dette komme opp som et alternativ. Kvitteringen blir sendt til mailen som er oppgitt under kjøpet.",
                        Votes = -4
                    },
                    new QA
                    {
                        Question = "Hvilke betalingsmetoder har dere?",
                        Answer = "Vi tilbyr bare kredittkort som betalingsmetode. Du kan benytte deg av automatene på de ulike stasjonene om du vil bruke kontanter",
                        Votes = 7
                    },
                    new QA
                    {
                        Question = "Toget er forsinket, hva har jeg krav på?",
                        Answer = "Er toget mer enn 30 min forsinket, har du krav på å få dekket alternativ transport. Ta gjerne kontakt med oss om det vil være tilfelle.",
                        Votes = 22
                    },
                    new QA
                    {
                        Question = "Hvor lenge før avreise kan jeg kjøpe togbillett?",
                        Answer = "Billetter legges ut for salg 90 dager før avgang. Det kan være kortere salgsperiode ved planlagte arbeider på strekningen eller i forbindelse med ruteendringer i juni og desember.",
                        Votes = 1
                    },
                    new QA
                    {
                        Question = "Kan jeg sitte i vanlig sete på nattoget?",
                        Answer = "Ja, og med sitteplass på nattoget får du en pakke med pute, pledd, øyemaske og ørepropper inkludert i prisen. Pakken henter du i kafévognen. Ta gjerne med deg pakken hjem, hvis ikke doneres pleddene til veldedig formål. De fleste stolene på nattoget kan justeres bakover.",
                        Votes = 5
                    }
                };
                foreach (var a in faq)
                {
                    dbContext.QA.Add(a);
                    dbContext.SaveChanges();
                }
            }
        }
    }

}


