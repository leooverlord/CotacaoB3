namespace Cotacao.Testes.Unitarios.Mocks
{
    public class StockDailyMock
    {
        public static string Data = @"{
                                        'Meta Data': {
                                            '1. Information': 'Daily Prices (open, high, low, close) and Volumes',
                                            '2. Symbol': 'petr4.sa',
                                            '3. Last Refreshed': '2020-08-14',
                                            '4. Output Size': 'Compact',
                                            '5. Time Zone': 'US/Eastern'
                                        },
                                        'Time Series (Daily)': {
                                            '2020-08-14': {
                                                '1. open': '22.7700',
                                                '2. high': '22.9800',
                                                '3. low': '22.5300',
                                                '4. close': '22.6700',
                                                '5. volume': '38146700'
                                            },
                                            '2020-08-13': {
                                        '1. open': '23.4500',
                                                '2. high': '23.5800',
                                                '3. low': '22.7100',
                                                '4. close': '22.8400',
                                                '5. volume': '44083100'
                                            },
                                            '2020-08-12': {
                                        '1. open': '23.3600',
                                                '2. high': '23.6800',
                                                '3. low': '23.0800',
                                                '4. close': '23.4800',
                                                '5. volume': '66472600'
                                            }
	                                    }
                                    }";
    }
}
