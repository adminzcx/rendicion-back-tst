declare module server {
	interface kmPriceConfiguration extends baseEntity {
		startDate?: Date;
		price: number;
		zone: {
		};
		subZone: {
			zone: {
			};
		};
		user: {
			firstName: string;
			lastName: string;
			email: string;
			employeeRecord: string;
			isAdministrator: boolean;
			branchFrom: {
				subZone: {
					zone: {
					};
				};
			};
			position: {
				isBranchRequired: boolean;
				isSubZoneRequired: boolean;
				isZoneRequired: boolean;
				isSectorRequired: boolean;
				isManagementRequired: boolean;
			};
			category: {
			};
			branch: {
				subZone: {
					zone: {
					};
				};
			};
			zone: {
			};
			subZone: {
				zone: {
				};
			};
			sector: {
				management: {
					hasSpecialPermissions: boolean;
				};
				hasSpecialPermissions: boolean;
			};
			management: {
				hasSpecialPermissions: boolean;
			};
			nextLevelAdmin: any;
			firstLevelPosition: any[];
			indirectsPosition: any[];
			paresLevelPosition: any[];
			name: string;
		};
		isDeleted: boolean;
		typeKm: number;
	}
	interface baseEntity {
		id: number;
	}
}
