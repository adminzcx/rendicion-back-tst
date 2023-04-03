declare module server {
	interface positionConfiguration extends baseEntity {
		position: {
			isBranchRequired: boolean;
			isSubZoneRequired: boolean;
			isZoneRequired: boolean;
			isSectorRequired: boolean;
			isManagementRequired: boolean;
		};
		reason: {
			concepts: any[];
		};
		concept: {
			form: number;
			reason: {
				concepts: any[];
			};
		};
	}
	interface baseEntity {
		id: number;
	}
}
