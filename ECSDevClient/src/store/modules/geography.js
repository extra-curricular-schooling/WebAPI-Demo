export const geography = {
  state: {
    /** The 50 state abbreviations of the United States of America */
    unitedStatesAbbrevs: Object.freeze(['AL', 'AK', 'AR', 'AZ', 'CA', 'CO', 'CT', 'DE', 'FL', 'GA', 'HI', 'IA', 'ID', 'IL', 'IN', 'KS', 'KY', 'LA', 'MA', 'MD', 'ME', 'MI', 'MN', 'MO', 'MS', 'MT', 'NC', 'ND', 'NE', 'NH', 'NJ', 'NM', 'NV', 'NY', 'OH', 'OK', 'OR', 'PA', 'RI', 'SC', 'SD', 'TN', 'TX', 'UT', 'VT', 'VA', 'WA', 'WI', 'WV', 'WY'])
  },
  getters: {
    /**
     * Retrieves unmodifiable list of all 50 United States
     * @param state The vuex state. Not to be confused with the geographical state.
     */
    getUnitedStatesAbbrevs: function (state) {
      return state.unitedStatesAbbrevs
    }
  },
  mutations: {

  },
  actions: {

  }
}
