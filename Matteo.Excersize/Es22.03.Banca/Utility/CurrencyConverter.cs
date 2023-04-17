using Es22._03.Banca.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    public class CurrencyConverter
    {
        static public decimal exchangeRateFiat(fiat currencySender, fiat currencyDestination)
        {
            decimal exchangeRateFiat = 0M;
            if (currencySender == currencyDestination) exchangeRateFiat = 1;
            else
            {
                switch (currencySender)
                {
                    case fiat.EUR:
                        switch (currencyDestination)
                        {
                            case fiat.RUB:
                                exchangeRateFiat = 90.52M;
                                break;
                            case fiat.USD:
                                exchangeRateFiat = 1.09M;
                                break;
                        }
                        break;
                    case fiat.RUB:
                        switch (currencyDestination)
                        {
                            case fiat.EUR:
                                exchangeRateFiat = 0.01M;
                                break;
                            case fiat.USD:
                                exchangeRateFiat = 0.02M;
                                break;
                        }
                        break;
                    case fiat.USD:
                        switch (currencyDestination)
                        {
                            case fiat.RUB:
                                exchangeRateFiat = 82.27M;
                                break;
                            case fiat.EUR:
                                exchangeRateFiat = 1.90M;
                                break;
                        }
                        break;
                }
            }
            return exchangeRateFiat;
        }

        static public decimal exchangeRateFiatToCrypto(fiat fiat, CRYPTO crypto)
        {
            decimal exchangeRateFiatToCrypto = 0;
            switch (fiat)
            {
                case fiat.EUR:
                    switch (crypto)
                    {
                        case CRYPTO.BTC:
                            exchangeRateFiatToCrypto =0.00003627M;
                            break;
                        case CRYPTO.ETH:
                            exchangeRateFiatToCrypto =0.00052108M;
                            break;
                    }
                    break;
                case fiat.RUB:
                    switch (crypto)
                    {
                        case CRYPTO.BTC:
                            exchangeRateFiatToCrypto = 0.00000040M;
                            break;
                        case CRYPTO.ETH:
                            exchangeRateFiatToCrypto =0.00000581M;
                            break;
                    }
                    break;
                case fiat.USD:
                    switch (crypto)
                    {
                        case CRYPTO.BTC:
                            exchangeRateFiatToCrypto = 0.00003306M;
                            break;
                        case CRYPTO.ETH:
                            exchangeRateFiatToCrypto = 0.00047426M;
                            break;
                    }
                    break;
            }
            return exchangeRateFiatToCrypto;
        }

        static public decimal exchangeRateCryptoToFiat(CRYPTO crypto, fiat fiat)
        {
            decimal exchangeRateCryptoToFiat = 0;
            switch (crypto)
            {
                case CRYPTO.BTC:
                    switch (fiat)
                    {
                        case fiat.EUR:
                            exchangeRateCryptoToFiat = 27583.33M;
                            break;
                        case fiat.USD:
                            exchangeRateCryptoToFiat = 30301.70M;
                            break;
                        case fiat.RUB:
                            exchangeRateCryptoToFiat = 2471103.64M;
                            break;
                    }
                    break;
                case CRYPTO.ETH:
                    switch (fiat)
                    {
                        case fiat.EUR:
                            exchangeRateCryptoToFiat = 1928.34M;
                            break;
                        case fiat.USD:
                            exchangeRateCryptoToFiat = 2118.38M;
                            break;
                        case fiat.RUB:
                            exchangeRateCryptoToFiat = 172753.89M;
                            break;
                    }
                    break;
            }
            return exchangeRateCryptoToFiat;
        }
        
    }
}
