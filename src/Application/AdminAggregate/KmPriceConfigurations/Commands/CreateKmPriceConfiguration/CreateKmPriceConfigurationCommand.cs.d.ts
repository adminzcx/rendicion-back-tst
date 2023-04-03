declare module server {
	interface createKmPriceConfigurationCommand {
		userId: number;
		zoneId: number;
		subZoneId: number;
		price: number;
		startDate?: Date;
		kmPriceType: any;
	}
}
